using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TheS.SmartCard;
using TimeScanner.DSA.EF;

namespace TimeScanner.ClickOnce
{
    public partial class Form1 : Form
    {
        private System.Threading.CancellationTokenSource cts = null;
        private string uniqueToken = "";
        public Form1()
        {
            InitializeComponent();

            NameValueCollection nameValueTable = new NameValueCollection();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                nameValueTable = HttpUtility.ParseQueryString(queryString);
            }
            uniqueToken = nameValueTable.Get(0);

            cts = new System.Threading.CancellationTokenSource();
            try
            {
                DoReadCard(this.cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void DoReadCard(System.Threading.CancellationToken token)
        {
            //acr33u    "ACS ACR33U-A1 3SAM ICC Reader ICC 0"
            //acr38     "ACS CCID USB Reader 0"

            //using (var mgr = new SmartCardReaderManager(new TheS.SmartCard.ACOSx86.AcosNoCardDetectionFactory("ACS ACR33U-A1 3SAM ICC Reader ICC 0")))
            using (var mgr = new SmartCardReaderManager(new TheS.SmartCard.ACOSx86.AcosCardReaderFactory()))
            {
                mgr.CardRemoved += mgr_CardRemoved;
                while (true != this.cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        //การ์ดเสียบอยู่มั้ย
                        var cardReader = await mgr.ConnectToReaderWhenNextCardInserted(token);
                        if (cardReader == null)
                        {
                            continue;
                        }

                        //อ่านข้อมูลจากการ์ด
                        using (var thaiCard = new TheS.SmartCard.Formatters.ThaiIdCardFormatter(cardReader))
                        {
                            //ดึงข้อมูลตัวหนังสือ
                            var MyInfo = await thaiCard.GetPersonalInfo();

                            var dac = new TimeScannerDBContainer();
                            if (!dac.TempEmployeeSet.Where(x => x.PID == MyInfo.PID).Any())
                            {
                                var emp = new TempEmployee()
                                {
                                    TitleName = MyInfo.NameTitle,
                                    FirstName = MyInfo.FirstName,
                                    LastName = MyInfo.LastName,
                                    Token = uniqueToken,
                                    PID = MyInfo.PID,
                                };
                                dac.TempEmployeeSet.Add(emp);
                                dac.SaveChanges();
                                label1.Text = "Read Complete !";
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                var emp = dac.TempEmployeeSet.Where(x => x.PID == MyInfo.PID).FirstOrDefault();
                                emp.Token = uniqueToken;
                                dac.SaveChanges();
                                label1.Text = "Read Complete !";
                            }
                        }
                    }
                    catch { }
                    System.Environment.Exit(0);
                }
                mgr.CardRemoved -= mgr_CardRemoved;
            }

        }

        private void mgr_CardRemoved(object sender, CardRemovedEventArgs e)
        {
        }
    }
}

