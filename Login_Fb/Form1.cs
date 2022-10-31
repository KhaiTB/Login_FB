using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Fb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int nCurrentItem = 0; // xác định hàng đang được click

        // Mình sẽ khai báo biến user, pass, 2fa để lúc chrome chạy lên có cái điền
        public string sUser, sPasss, s2FA;

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Tách data thành các dòng riêng biệt
            string[] lsInfo = rdDataImport.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int nIndex = 0;
            foreach(var detailInfo in lsInfo)
            {
                if(detailInfo == "")
                {
                    continue;
                }

                // Tách thành từng data như mail, pass, 2FA
                string[] sInfo = detailInfo.Split(new[] { "|" }, StringSplitOptions.None); 

                // Insert to datagirdview
               if(sInfo.Length == 2) // data chứa user, pass
                {
                    dataGridView1.Rows.Insert(nIndex, nIndex + 1, sInfo[0], sInfo[1]);
                }else if (sInfo.Length == 3) // data chứa user, passs, 2FA
                {
                    dataGridView1.Rows.Insert(nIndex, nIndex + 1, sInfo[0], sInfo[1], sInfo[2]);
                }
                else if (sInfo.Length == 4)// data chứa user, passs, 2FA, proxy
                {
                    dataGridView1.Rows.Insert(nIndex, nIndex + 1, sInfo[0], sInfo[1], sInfo[2], sInfo[3]);
                }
                else if (sInfo.Length == 5)// data chứa user, passs, 2FA, proxy, ghi chú
                {
                    dataGridView1.Rows.Insert(nIndex, nIndex + 1, sInfo[0], sInfo[1], sInfo[2], sInfo[3], sInfo[4]);
                }
                nIndex++;
            }    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lưu lại vị trí người dùng mới click
            nCurrentItem = e.RowIndex;
        }

        private void loginEmailPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khi người dùng click login bằng user | pass

            //  ==> Để tạo được hành vi này cài đặt chrome, selenium
            // B1: khởi tạo chrome
            ChromeDriverService driverService = null;
            ChromeDriver driver = null;
            IWebElement item = null;

            driverService = ChromeDriverService.CreateDefaultService(".\\");
            driverService.HideCommandPromptWindow = true;

            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(
                "--headless",
                "--verbose",
                //"--incognito",
                "--disable-web-security",
                "--ignore-certificate-errors",
                "--allow-running-insecure-content",
                "--allow-insecure-localhost"
                );

            chromeOptions.AddUserProfilePreference("webrtc.ip_handling_policy", "disable_non_proxied_udp");
            chromeOptions.AddUserProfilePreference("webrtc.multiple_routes_enabled", false);
            chromeOptions.AddUserProfilePreference("webrtc.nonproxied_udp_enabled", false);
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 1);

            chromeOptions.AddArgument("--mute-audio");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--disable-software-rasterizer");
            chromeOptions.AddArgument("--no-first-run");
            chromeOptions.AddArgument("--no-service-autorun");
            chromeOptions.AddArgument("--password-store=basic");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddExcludedArgument("enable-automation");

            driver = new ChromeDriver(driverService, chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("https://m.facebook.com");

            // B2: Tìm xpath hoặc id để điền email
            item = driver.FindElement(By.Id("m_login_email"));
            // B2.1: Ta lấy email từ chỗ click ra để điền, ta đã có vị trí dòng đang click, truy nhập dòng đó lấy ra thôi
            sUser = dataGridView1.Rows[nCurrentItem].Cells[1].Value.ToString();  // => email là vị trí cột thứ 2 tại dòng ta đang click
            // B2.2: Ta điền email vào phần email trên facebook
            item.SendKeys(sUser);

            // B3: Ta tìm chỗ điền password
            item = driver.FindElement(By.Id("m_login_password"));
            // B3.1: Ta lấy pass từ chỗ click ra để điền
            sPasss = dataGridView1.Rows[nCurrentItem].Cells[2].Value.ToString();  // => pass là vị trí cột thứ 3 tại dòng ta đang click
            item.SendKeys(sPasss);

            // B4: Ta tìm button click để login
            item = driver.FindElement(By.XPath("//*[@id=\"login_password_step_element\"]/button"));
            item.Click();

            // ==> Xong phần login bằng user | pass, ta chuyển sang phần login bằng 2FA
        }

        // Hoàn toàn tương tự, khi click có 2FA thì đến đoạn sau ta cần lấy code 2FA
        private void loginEmailPass2FAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khi người dùng click bằng user | pass| 2FA

            // Khi người dùng click login bằng user | pass

            //  ==> Để tạo được hành vi này cài đặt chrome, selenium
            // B1: khởi tạo chrome
            ChromeDriverService driverService = null;
            ChromeDriver driver = null;
            IWebElement item = null;

            driverService = ChromeDriverService.CreateDefaultService("C:\\Users\\Admin\\source\\repos\\Login_Fb\\Login_Fb\\bin\\Debug");
            driverService.HideCommandPromptWindow = true;

            ChromeOptions chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(
                "--verbose",
                //"--incognito",
                "--disable-web-security",
                "--ignore-certificate-errors",
                "--allow-running-insecure-content",
                "--allow-insecure-localhost"
                );

            chromeOptions.AddUserProfilePreference("webrtc.ip_handling_policy", "disable_non_proxied_udp");
            chromeOptions.AddUserProfilePreference("webrtc.multiple_routes_enabled", false);
            chromeOptions.AddUserProfilePreference("webrtc.nonproxied_udp_enabled", false);
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 1);

            chromeOptions.AddArgument("--mute-audio");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--disable-software-rasterizer");
            chromeOptions.AddArgument("--no-first-run");
            chromeOptions.AddArgument("--no-service-autorun");
            chromeOptions.AddArgument("--password-store=basic");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddExcludedArgument("enable-automation");

            driver = new ChromeDriver(driverService, chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("https://m.facebook.com");
            Thread.Sleep(2000);

            // B2: Tìm xpath hoặc id để điền email
            item = driver.FindElement(By.Id("m_login_email"));
            // B2.1: Ta lấy email từ chỗ click ra để điền, ta đã có vị trí dòng đang click, truy nhập dòng đó lấy ra thôi
            sUser = dataGridView1.Rows[nCurrentItem].Cells[1].Value.ToString();  // => email là vị trí cột thứ 2 tại dòng ta đang click
            // B2.2: Ta điền email vào phần email trên facebook
            item.SendKeys(sUser);
            Thread.Sleep(1000);

            // B3: Ta tìm chỗ điền password
            item = driver.FindElement(By.Id("m_login_password"));
            // B3.1: Ta lấy pass từ chỗ click ra để điền
            sPasss = dataGridView1.Rows[nCurrentItem].Cells[2].Value.ToString();  // => pass là vị trí cột thứ 3 tại dòng ta đang click
            item.SendKeys(sPasss);
            Thread.Sleep(1000);

            // B4: Ta tìm button click để login
            item = driver.FindElement(By.XPath("//*[@id=\"login_password_step_element\"]/button"));
            item.Click();
            Thread.Sleep(1000);

            // ==> Xong phần login bằng user | pass, ta chuyển sang phần login bằng 2FA
            string s2FA = dataGridView1.Rows[nCurrentItem].Cells[3].Value.ToString(); // => 2FA là vị trí cột thứ 4 tại dòng ta đang click
            string s2FACode = GetCode(s2FA);

            // B5: Ta tìm vị trí điền 2FA
            item = driver.FindElement(By.Id("approvals_code"));
            item.SendKeys(s2FACode);
            Thread.Sleep(1000);

            // B6: Ta click vào button 2FA
            item = driver.FindElement(By.Id("checkpointSubmitButton-actual-button"));
            item.SendKeys(s2FACode);
            item.Click();

            //==> Hoàn thành check code bằng 2FA
        }

        // Ta sẽ viết hàm lấy 2FA tại đây, đầu vào là chuổi 2FA, trả ra là code
        public string GetCode(string s2FA)
        {
            string sCode = "";

            var client = new RestClient("https://2fa.vn/server");
            client.Timeout = 15000;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authority", "2fa.vn");
            request.AddHeader("accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("accept-language", "en-US,en;q=0.9");
            request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("cookie", "PHPSESSID=uithlpksu7aqoobltpopk0opgc; _ga_L553VMWZW6=GS1.1.1667246078.1.0.1667246078.0.0.0; _ga=GA1.1.1818061002.1667246079");
            request.AddHeader("origin", "https://2fa.vn");
            request.AddHeader("referer", "https://2fa.vn/");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"106\", \"Google Chrome\";v=\"106\", \"Not;A=Brand\";v=\"99\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36";
            request.AddHeader("x-requested-with", "XMLHttpRequest");
            var body = @"secrets=%5B%22OO6Y57NT4IQEPPA6J7JIN4ORVRRY52GE%22%5D";
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            // sau khi có kết quả trả về ta cần lọc ra cái code
            string sResponse = response.Content.Substring(response.Content.IndexOf("code"));
            sCode = Regex.Match(sResponse, @"\d+").Value;

            // 2 dòng code trên là ta lấy ra mã code

            return sCode;
        }
    }
}
