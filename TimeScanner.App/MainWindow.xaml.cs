using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheS.SmartCard;
using TimeScanner.DSA.EF;

namespace TimeScanner.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Threading.CancellationTokenSource cts = null;

        public MainWindow()
        {
            InitializeComponent();

            CurrentDate.Content = DateTime.Now.ToString("dd MMMM yyyy", System.Globalization.CultureInfo.GetCultureInfo("th-TH"));

            cts = new System.Threading.CancellationTokenSource();
            try
            {
                DoReadCard(this.cts.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            RefreshDataGrid();
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

                            //ดึงรูป
                            var imgData = await thaiCard.GetPictureData();
                            using (var ms = new System.IO.MemoryStream(imgData))
                            {
                                var decoder = new JpegBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);

                                WriteableBitmap writable = new WriteableBitmap(decoder.Frames.Single());
                                writable.Freeze();

                                image.Source = writable;
                            }

                            //โชว์ค่า
                            TitleNameTextBox.Text = MyInfo.NameTitle;
                            FirstNameTextBox.Text = MyInfo.FirstName;
                            LastNameTextBox.Text = MyInfo.LastName;
                            TimeLabel.Content = DateTime.Now.ToString("HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("th-TH"));

                            //สร้างตัวเชื่อมต่อฐานข้อมูล
                            var dac = new TimeScannerDBContainer();

                            //query ข้อมูลพนักงาน
                            var emp = dac.EmployeeSet.Where(x => x.PID == MyInfo.PID);
                            //ถ้ามีข้อมูลพนักงาน
                            if (emp.Any())
                            {
                                //สร้างชุดข้อมูลเปล่า
                                var timescan = new TimeScan();

                                //query ดูว่ามีการสแกนเวลาวันนี้หรือยัง
                                var date1 = DateTime.Today;
                                var date2 = DateTime.Today.AddDays(1);
                                var hasScan = dac.TimeScanSet.Where(x =>
                                    x.EmployeeId== emp.FirstOrDefault().Id &&
                                    ((x.TimeIn.HasValue && x.TimeIn >= date1 && x.TimeIn < date2) ||
                                    (x.TimeOut.HasValue && x.TimeOut >= date1 && x.TimeOut < date2)));

                                //ถ้าเคยมีการสแกนวันนี้แล้ว
                                if (hasScan.Any())
                                {
                                    //ใช้ชุดข้อมูลของวันนี้
                                    timescan = hasScan.FirstOrDefault();
                                }
                                else
                                {
                                    //ถ้ายังไม่มีการสแกน ใส่รหัสพนักงานลงในชุดข้อมูลเปล่ที่สร้างไว้
                                    timescan.EmployeeId = emp.FirstOrDefault().Id;
                                }

                                //ดูว่าเป็นการสแกนเวลาเข้าหรือออก
                                if (TimeInRadioButton.IsChecked.HasValue && TimeInRadioButton.IsChecked.Value)
                                {
                                    timescan.TimeIn = DateTime.Now;
                                }
                                else
                                {
                                    timescan.TimeOut = DateTime.Now;
                                }

                                //ถ้ายังไม่เคยมีการสแกนวันนี้ ให้ใช้คำสั่งเพิ่มชุดข้อมูลใหม่
                                if (!hasScan.Any())
                                {
                                    dac.TimeScanSet.Add(timescan);
                                }
                                //ยืนยันการบันทึก
                                dac.SaveChanges();
                                statusLabel.Content = "success.";
                                RefreshDataGrid();
                            }
                            else
                            {
                                //ถ้าไม่มีข้อมูลพนักงาน
                                statusLabel.Content = "Employee not found.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Content = ex.ToString(); ;
                    }
                }
                mgr.CardRemoved -= mgr_CardRemoved;
            }

        }

        private void mgr_CardRemoved(object sender, CardRemovedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                TitleNameTextBox.Text = "";
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                TimeLabel.Content = "";
                statusLabel.Content = "";

                image.Source = null;
            });
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //    //สร้างตัวเชื่อมต่อฐานข้อมูล

            //    var dac = new TimeScannerDBContainer();
            //    //สร้างชุดข้อมูล พนง.
            //    var emp = new Employee();
            //    //LastName.Content = MyInfo.LastName;  อันเก่าแสดงข้อมูลตัวหนังสือ

            //    //ใส่ textbox เพื่อให้ข้อมูลแสดงใน textbox แทน
            //    emp.EmployeeCode = textBox7.Text;
            //    emp.PID = PID.Text;
            //    emp.TitleName = TitleNameTextBox.Text;
            //    emp.FirstName = FirstNameTextBox.Text;
            //    emp.LastName = LastNameTextbox.Text;
            //    emp.Position = textBox4.Text;
            //    emp.Email = textBox5.Text;
            //    emp.Tel = textBox6.Text;
            //    //เตรียมเพิ่มข้อมูล พนง.
            //    dac.EmployeeSet.Add(emp);
            //    //ยืนยันการบันทึก
            //    dac.SaveChanges();
            //    //รีเฟรชตาราง
            //    dataGrid.Items.Clear();
            //    foreach (var item in dac.EmployeeSet)
            //    {
            //        dataGrid.Items.Add(item);
            //    }
        }

        private void RefreshDataGrid()
        {
            var dac = new TimeScannerDBContainer();
            var date1 = DateTime.Today;
            var date2 = DateTime.Today.AddDays(1);
            var timeScans = dac.TimeScanSet.Where(xx =>
                         (xx.TimeIn.HasValue && xx.TimeIn >= date1 && xx.TimeIn < date2) ||
                         (xx.TimeOut.HasValue && xx.TimeOut >= date1 && xx.TimeOut < date2)).ToList();

            var qry = dac.EmployeeSet.ToList().Select(x =>
            {
                var timeScan = timeScans.Where(xx => xx.EmployeeId == x.Id).FirstOrDefault();
                return new
                {
                    EmployeeCode = x.EmployeeCode,
                    FullName = x.TitleName + x.FirstName + " " + x.LastName,
                    TimeIn = timeScan != null && timeScan.TimeIn.HasValue ? timeScan.TimeIn.Value.ToString("HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("th-TH")) : "--:--:--",
                    TimeOut = timeScan != null && timeScan.TimeOut.HasValue ? timeScan.TimeOut.Value.ToString("HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("th-TH")) : "--:--:--",
                };
            }).ToList();

            dataGrid.ItemsSource = qry;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();

        }
    }
}
