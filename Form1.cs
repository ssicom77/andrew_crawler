using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }


        StringBuilder sbList = new StringBuilder(8000);

        String sRowData = String.Empty;

        String orgHandle = String.Empty;

        private int cnt = 0;

        private Thread rTh;

        private static List<IWebElement> listHospital = new List<IWebElement>(10000);


        private int nLast = 0;


        private String sLinkDetailPage = String.Empty;
        private String sLink = String.Empty;



        private static ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
        //private static FirefoxDriverService driverService = FirefoxDriverService.CreateDefaultService();
        //private static InternetExplorerDriverService

        
        private static ChromeOptions options = new ChromeOptions();
        //private static FirefoxOptions options = new FirefoxOptions();


        private static ChromeDriver globalDriver;
        //private static FirefoxDriver driver;
        //private static InternetExplorerDriver driver;

        //private static ChromeDriver driverDetail = new ChromeDriver(driverService, options);


        // Go to the home page 


        //WebDriverWait webDriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));



        private void Form1_Load(object sender, EventArgs e)
        {
            //InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();
            //service.SuppressInitialDiagnosticInformation = true;

            //options.AddArgument("no-sandbox");
            options.AddArgument("ignore-certificate-errors");
            //options.AddArgument("--disable-gpu");
            // 프록시 설정 
            //Proxy proxy = new Proxy(); 
            //proxy.Kind = ProxyKind.Manual; 
            //proxy.IsAutoDetect = false; 
            //proxy.HttpProxy = proxy.SslProxy = ip;
            //options.Proxy = proxy;


            //options.AddArgument("--disable-extensions");


            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            if (File.Exists(Application.StartupPath + @"\lastNo.txt"))
                textBox1.Text = File.ReadAllText(Application.StartupPath + @"\lastNo.txt");
            else
                textBox1.Text = "0";

            driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
            driverService.Start();


            globalDriver = new ChromeDriver(driverService, options, TimeSpan.FromMinutes(3));
            //driver = new FirefoxDriver(driverService, options);
            //driver = new InternetExplorerDriver(service, options);





            globalDriver.Navigate().GoToUrl("http://www.longtermcare.or.kr/npbs/r/a/201/selectLtcoSrch.web?menuId=npe0000000650&zoomSize=");

                this.txtLog.Text = this.txtLog.Text + string.Format("Url 이동 : {0}", globalDriver.Url) + Environment.NewLine;
 


                //selectEl.SelectByValue("11");

                //sidoCode.SendKeys("11");
                

                


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 디테일 페이지용 재정의
            options.AddArgument("ignore-certificate-errors");
            options.AddArguments("disable-infobars");
            options.AddArguments("--js-flags=--expose-gc");
            options.AddArguments("--enable-precise-memory-info");
            options.AddArguments("--disable-popup-blocking");
            options.AddArguments("--disable-default-apps");
            options.AddArgument("--headless --disable-gpu");


            //driver.ExecuteScript("alert($('#si_do_cd').val());");

            String sLocalCd = "";

            if (rdo11.Checked) sLocalCd = "11";
            else if (rdo26.Checked) sLocalCd = "26";
            else if (rdo27.Checked) sLocalCd = "27";
            else if (rdo28.Checked) sLocalCd = "28";
            else if (rdo29.Checked) sLocalCd = "29";
            else if (rdo30.Checked) sLocalCd = "30";
            else if (rdo31.Checked) sLocalCd = "31";
            else if (rdo36.Checked) sLocalCd = "36";
            else if (rdo41.Checked) sLocalCd = "41";
            else if (rdo42.Checked) sLocalCd = "42";
            else if (rdo43.Checked) sLocalCd = "43";
            else if (rdo44.Checked) sLocalCd = "44";
            else if (rdo45.Checked) sLocalCd = "45";
            else if (rdo46.Checked) sLocalCd = "46";
            else if (rdo47.Checked) sLocalCd = "47";
            else if (rdo48.Checked) sLocalCd = "48";
            else if (rdo50.Checked) sLocalCd = "50";

            globalDriver.ExecuteScript("$('#si_do_cd').val('"+ sLocalCd + "');"); // added single quotes

            System.Threading.Thread.Sleep(200);
            Application.DoEvents();
            System.Threading.Thread.Sleep(200);
            Application.DoEvents();
            System.Threading.Thread.Sleep(200);
            Application.DoEvents();

            globalDriver.ExecuteScript("$('#record_cnt_per_pag').val('10000');"); // added single quotes

            globalDriver.ExecuteScript("var pageInfo = {        pageSize: 10,        recordCountPerPage: 500,        currentPageNo: 1,        firstPageNo: 1,        firstPageNoOnPageList: 1,        totalPageCount: 1,        lastPageNoOnPageList: 1,        lastPageNo: 1,        totalRecordCount: 0    };gfn_setPagination(pageInfo, \"main_paging\", \"ltco_info\", \"ltco_info_list\");");
            System.Threading.Thread.Sleep(200);
            Application.DoEvents();
            System.Threading.Thread.Sleep(200);
            Application.DoEvents();




            globalDriver.ExecuteScript("$('#btn_search').click();");

            Application.DoEvents();

            //driver.ExecuteScript("var data = {siDoCd: $(\"#si_do_cd\").val() };        $(\"#ltco_info\").attr(\"action\", \"/npbs/r/a/201/selectLtcoSrchExcel.web\");        $('#excelCurrPage').val(pageInfo.currentPageNo);        $(\"#cu_pag_no\").val(pageInfo.currentPageNo);        gfn_submit($(\"#ltco_info\"));        $(\"#ltco_info\").attr(\"action\", \"/npbs/r/a/201/selectLtcoSrch.web\");");



            // driver.ExecuteScript("$('#ltc_admin_nm').val('test');"); // added single quotes


            //driver.ExecuteScript("$('#si_do_cd').val('11')");

            //driver.ExecuteScript("alert($('#si_do_cd').val());");

            //driver.ExecuteScript("$('#siDoCd').val('11');");



        }


        private void button2_Click(object sender, EventArgs e)
        {

            orgHandle = globalDriver.WindowHandles[0];

            listHospital = globalDriver.FindElementById("ltco_info_list").FindElements(By.TagName("tr")).ToList();


            //foreach (IWebElement iw in listHospital)
            //{
            //    if (i>=1)
            //        setLog2( "ROWS >> "  + iw.FindElements(By.TagName("td"))[0].Text + "  / " + iw.FindElements(By.TagName("td")).Count.ToString());

            //    i++;
            //}

            int i = 0;

            i = 1;

            i = int.Parse(textBox1.Text.Trim());

            if (i == 0)
            {
                i = 0;
            }
            else if (i > 0)
            {
                i = i - 1;
            }


            nMultiCnt = int.Parse(textBox2.Text.Trim());

            if (nMultiCnt == 0) nMultiCnt = 1;

            nCurThreadCnt = 0;

            while (true)
            {

                if (listHospital.Count == i)
                    break;
                else
                {
                    if (nCurThreadCnt<nMultiCnt)
                    {
                        nCurThreadCnt++;

                        i++;

                        rTh = new Thread(() => procGetData(i,globalDriver, orgHandle));

                        rTh.TrySetApartmentState(ApartmentState.MTA);

                        rTh.Start();

                        

                    }

                    for (int cc = 0; cc <10; cc++)
                    {
                        Thread.Sleep(100);
                        Application.DoEvents();

                    }
                    
                }
            }
            //procGetData(1);
        }

        private Boolean bIsWorking = false;

        private int nMultiCnt = 1;
        private int nCurThreadCnt = 0;
        
        //private void procGetData2()
        //{
       
        //    //Console.WriteLine(i.ToString());

        //    int curRowNo = int.Parse(removeComma(listHospital[i].FindElements(By.TagName("td"))[0].Text));

        //    //Console.WriteLine("#Cur : " + curRowNo.ToString());

        //    Thread.Sleep(100);

        //    i++;

        //    bIsWorking = false;
 
        //}

        private IWebElement tempEl;

        

        private void procGetData(int i ,ChromeDriver driver, String orgHandle)
        {
            

            String sAdminSym = String.Empty;
            String sPttnCd = String.Empty;
            String sRowNo = "";

        ////Console.WriteLine(i.ToString());

        //setLog2(removeComma(listHospital[i].FindElements(By.TagName("td"))[0].Text) + "  / " + textBox1.Text);

        int curRowNo = int.Parse(removeComma(listHospital[i].FindElements(By.TagName("td"))[0].Text));

            //Console.WriteLine("Current Row Number : " + i.ToString() + " / " + curRowNo.ToString());

            if (listHospital[i] != null) // &&  (curRowNo > int.Parse(textBox1.Text)))
            {

                JObject specDetail = new JObject();


                sRowData = String.Empty;

                //this.txtLog.AppendText("----------------------------------------------------------------------------------------"+Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[0].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[1].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[2].Text + Environment.NewLine);

                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[3].Text + Environment.NewLine);

                sRowNo = listHospital[i].FindElements(By.TagName("td"))[0].Text;


                try
                {
                    sLinkDetailPage = listHospital[i].FindElements(By.TagName("td"))[3].FindElements(By.TagName("a"))[0].GetAttribute("href");

                    sLink = sLinkDetailPage.Split('?')[1];

                    sAdminSym = sLink.Split('&')[0].Replace("ltcAdminSym=", "");
                    sPttnCd = sLink.Split('&')[1].Replace("adminPttnCd=", "");

                    sAdminSym = sAdminSym + "_" + sPttnCd;

                    //this.txtLog.AppendText(sAdminSym + Environment.NewLine);

                    //this.txtLog.AppendText(sPttnCd + Environment.NewLine);

                }
                catch (Exception err)
                {

                }




                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[4].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[5].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[6].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[7].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[8].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[9].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[10].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[11].Text + Environment.NewLine);
                //this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[12].Text +Environment.NewLine);

                sRowData = removeComma(listHospital[i].FindElements(By.TagName("td"))[0].Text);

                specDetail.Add("NO", removeComma(listHospital[i].FindElements(By.TagName("td"))[0].Text));

                // 장기요양기관
                //sRowData += sRowData + "," + removeComma(listHospital[i].FindElements(By.TagName("td"))[3].Text);
                specDetail.Add("기관명", removeComma(listHospital[i].FindElements(By.TagName("td"))[3].Text));

                // 급여종류 
                //sRowData += sRowData + "," + removeComma(listHospital[i].FindElements(By.TagName("td"))[1].Text);
                specDetail.Add("급여종류", removeComma(listHospital[i].FindElements(By.TagName("td"))[1].Text));

                //// 관리코드
                //sRowData += sRowData + "," + removeComma(sAdminSym);

                // 패턴코드
                //sRowData += sRowData + "," + removeComma(sPttnCd);
                specDetail.Add("패턴코드", removeComma(sPttnCd));



                //listHospital[i].FindElements(By.TagName("td"))[3].FindElements(By.TagName("a"))[0].Click();

                String sTempLink = listHospital[i].FindElements(By.TagName("td"))[3].FindElements(By.TagName("a"))[0].GetAttribute("href");

                sTempLink =  sTempLink + "&showVlt=Y";


                ChromeDriverService detaildriverService = ChromeDriverService.CreateDefaultService();
                detaildriverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 
                detaildriverService.Start();

                ChromeDriver detailDriver = new ChromeDriver(detaildriverService, options, TimeSpan.FromMinutes(1));
                //driver = new FirefoxDriver(driverService, options);
                //driver = new InternetExplorerDriver(service, options);

                detailDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 2);

                detailDriver.Navigate().GoToUrl(sTempLink);

                


                //foreach (string handle in driver.WindowHandles)
                //{
                //    IWebDriver popup = driver.SwitchTo().Window(handle);

                //    if (popup.Title.Contains("장기요양기관 상세"))
                //    {
                //        break;
                //    }
                //}


                detailDriver.ExecuteScript("document.getElementById('equip1').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('equip').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('dmtiaEquip').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('dmtiaJlfEquip').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('dmtiaDayEquip').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('dmtiaFixnum').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('apprv1').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('equip2').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('apprv2').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('ratDiv').setAttribute('style', 'display:;');");
                System.Threading.Thread.Sleep(10);
                detailDriver.ExecuteScript("document.getElementById('vltGradeCd').setAttribute('style', 'display:;');");

                System.Threading.Thread.Sleep(100);

                //for (int n = 0; n < 10; n++)
                //{
                //    System.Threading.Thread.Sleep(200);
                //    Application.DoEvents();
                //}



                // 일반현황 - 최종변경일
                //sRowData += sRowData + "," + getLastUpdate("일반현황");
                specDetail.Add("일반현황 - 최종변경일", removeComma(getLastUpdate("일반현황", detailDriver)));

                // 장기요양기관 기관번호
                //sRowData += sRowData + "," + removeComma(sAdminSym);
                specDetail.Add("장기요양기관 기관번호", removeComma(sAdminSym));


                try
                {
                    //// 주소 
                    //sRowData += sRowData + "," + getTextValue("th", "주소").Split('(')[0];

                    //// 주소 - 동
                    //sRowData += sRowData + "," + getTextValue("th", "주소").Split('(')[1].Replace(")", "");

                    specDetail.Add("주소", getTextValue("th", "주소", detailDriver).Split('(')[0]);
                    specDetail.Add("동이름", getTextValue("th", "주소", detailDriver).Split('(')[1].Replace(")", ""));
                }
                catch (Exception err)
                {
                    setLog(err.Message);
                    setLog(err.StackTrace);

                    // 주소 
                    sRowData += sRowData + "," + getTextValue("th", "주소", detailDriver);

                    // 주소 - 동
                    sRowData += sRowData + "," + "분리실패";
                }


                // 전화번호
                //sRowData += sRowData + "," + getTextValue("th", "전화번호");
                specDetail.Add("전화번호", getTextValue("th", "전화번호", detailDriver));

                // 제공서비스
                //sRowData += sRowData + "," + getTextValue("th", "제공서비스");
                specDetail.Add("제공서비스", getTextValue("th", "제공서비스", detailDriver));

                // 통합재가급여 제공
                //sRowData += sRowData + "," + getTextValue("th", "통합재가급여 제공");
                specDetail.Add("통합재가급여 제공", getTextValue("th", "통합재가급여 제공", detailDriver));

                // 통합재가급여 유형
                //sRowData += sRowData + "," + getTextValue("th", "통합재가급여 유형");
                specDetail.Add("통합재가급여 유형", getTextValue("th", "통합재가급여 유형", detailDriver));

                // 홈페이지 주소
                //sRowData += sRowData + "," + getTextValue("th", "홈페이지 주소");
                specDetail.Add("홈페이지 주소", getTextValue("th", "홈페이지 주소", detailDriver));

                // 지정일자
                //sRowData += sRowData + "," + getTextValue("th", "지정일자");
                specDetail.Add("지정일자", getTextValue("th", "지정일자", detailDriver));

                // 설치신고일자
                //sRowData += sRowData + "," + getTextValue("th", "설치신고일자");
                specDetail.Add("설치신고일자", getTextValue("th", "설치신고일자", detailDriver));

                // 교통편
                //sRowData += sRowData + "," + getTextValue("th", "교통편").Replace("\n", "");
                specDetail.Add("교통편", getTextValue("th", "교통편", detailDriver).Replace("\n", "").Replace("\r", ""));

                // 주차시설
                //sRowData += sRowData + "," + getTextValue("th", "주차시설").Replace("\n", "").Replace("\r", "");
                specDetail.Add("주차시설", getTextValue("th", "주차시설", detailDriver).Replace("\n", "").Replace("\r", ""));


                // 전문인배상책임보험
                //sRowData += sRowData + "," + getTextValue("th", "전문인배상책임보험").Replace("\n", "").Replace("\r", "");
                specDetail.Add("전문인배상책임보험", getTextValue("th", "전문인배상책임보험", detailDriver).Replace("\n", "").Replace("\r", ""));

                // 손해배상책임보험
                //sRowData += sRowData + "," + getTextValue("th", "손해배상책임보험").Replace("\n", "").Replace("\r", "");
                specDetail.Add("손해배상책임보험", getTextValue("th", "손해배상책임보험", detailDriver).Replace("\n", "").Replace("\r", ""));

                // 정원
                //sRowData += sRowData + "," + getTextValue("th", "정원(A)").Replace("\n", "").Replace("\r", "");
                specDetail.Add("정원", getTextValue("th", "정원(A)", detailDriver).Replace("\n", "").Replace("\r", ""));


                try
                {
                    // 정원 - 세부 - 남자
                    //sRowData += sRowData + "," + getTextValue("th", "현원(B)").Split('\n')[0].Split('명')[0].Replace("남", "").Replace("명", "").Replace(":", "");
                    //setLog("정원-세부-남자 >> " + getTextValue("th", "현원(B)").Split('\n')[0].Split('명')[0].Replace("남", "").Replace("명", "").Replace(":", ""));
                    specDetail.Add("현원-남자", getTextValue("th", "현원(B)", detailDriver).Split('\n')[0].Split('명')[0].Replace("남", "").Replace("명", "").Replace(":", ""));
                }
                catch (Exception err)
                {
                    sRowData += sRowData + "," + getTextValue("th", "현원(B)", detailDriver);
                    setLog("Err " + getTextValue("th", "현원(B)", detailDriver));
                }

                try
                {
                    // 정원 - 세부 - 여자
                    //sRowData += sRowData + "," + getTextValue("th", "현원(B)").Split('\n')[0].Split('명')[1].Replace("여", "").Replace("명", "").Replace(":", "");

                    specDetail.Add("현원-여자", getTextValue("th", "현원(B)", detailDriver).Split('\n')[0].Split('명')[1].Replace("여", "").Replace("명", "").Replace(":", ""));

                    //setLog("정원-세부-여자 >> " + getTextValue("th", "현원(B)").Split('\n')[0].Split('명')[1].Replace("여", "").Replace("명", "").Replace(":", ""));
                }
                catch (Exception err)
                {
                    sRowData += sRowData + "," + getTextValue("th", "현원(B)", detailDriver);
                    setLog("Err " + getTextValue("th", "현원(B)", detailDriver));
                }

                try
                {
                    // 정원 - 세부 - 대기자 - 남자
                    //sRowData += sRowData + "," + getTextValue("th", "현원(B)").Split('\n')[1].Replace("대기자-남", "").Replace("명", "").Replace(":", "").Replace(",", "");

                    specDetail.Add("현원-대기자-남자", getTextValue("th", "현원(B)", detailDriver).Split('\n')[1].Replace("대기자-남", "").Replace("명", "").Replace(":", "").Replace(",", ""));

                    //setLog("정원-세부-대기남 >> " + getTextValue("th", "현원(B)").Split('\n')[1].Replace("대기자-남", "").Replace("명", "").Replace(":", "").Replace(",", ""));
                }
                catch (Exception err)
                {
                    sRowData += sRowData + "," + getTextValue("th", "현원(B)", detailDriver);
                    setLog("Err " + getTextValue("th", "현원(B)", detailDriver));
                }

                try
                {
                    // 정원 - 세부 - 대기자 - 여자
                    //sRowData += sRowData + "," + getTextValue("th", "현원(B)").Split('\n')[2].Replace("대기자-여", "").Replace("명", "").Replace(":", "").Replace(",", "");
                    specDetail.Add("현원-대기자-여자", getTextValue("th", "현원(B)", detailDriver).Split('\n')[2].Replace("대기자-여", "").Replace("명", "").Replace(":", "").Replace(",", ""));
                    //setLog("정원-세부-대기녀 >> " + getTextValue("th", "현원(B)").Split('\n')[2].Replace("대기자-여", "").Replace("명", "").Replace(":", "").Replace(",", ""));
                }
                catch (Exception err)
                {
                    sRowData += sRowData + "," + getTextValue("th", "현원(B)", detailDriver);
                    setLog("Err " + getTextValue("th", "현원(B)", detailDriver));
                }

                try
                {
                    // 정원 - 세부 - 갱신일
                    //sRowData += sRowData + "," + getTextValue("th", "현원(B)").Split('\n')[3].Replace("(", "").Replace(")", "");
                    specDetail.Add("현원-갱신일", getTextValue("th", "현원(B)", detailDriver).Split('\n')[3].Replace("(", "").Replace(")", ""));
                    //setLog(getTextValue("th", "현원(B)").Split('\n')[3].Replace("(", "").Replace(")", ""));
                }
                catch (Exception err)
                {
                    sRowData += sRowData + "," + "없음";
                    setLog("없음");
                }

                // 이용가능인원(A-B)

                try
                {
                    //sRowData += sRowData + "," + getTextValue("th", "이용가능인원(A-B)");
                    specDetail.Add("이용가능인원(A-B)", getTextValue("th", "이용가능인원(A-B)", detailDriver));
                }
                catch (Exception err)
                {
                    sRowData += sRowData + "," + "";
                }

                

                if (checkTitle("인력현황", detailDriver))
                {
                    JObject spec = new JObject();
                    spec.Add("관리코드", sAdminSym);

                    spec.Add("최종변경일", getLastUpdate("인력현황", detailDriver));


                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("인력현황 정보"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }

                    int nColspanPosProc = 0;

                    if (tempTable != null)
                    {
                        if (tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr")).Count > 1)
                        {
                            List<String> listJobTitle = new List<string>();

                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTemp = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[0].FindElements(By.TagName("th"));


                            int nColsapnTrCnt = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th")).Count;

                            int curColspanPos = 0;

                            foreach (IWebElement objTh in listThTemp)
                            {

                                if (objTh.GetAttribute("colspan") != null && objTh.GetAttribute("colspan") != "")



                                {

                                    setLog(objTh.Text + " " + objTh.GetAttribute("colspan"));

                                    String sJob1 = objTh.Text;

                                    int colspan = int.Parse(objTh.GetAttribute("colspan"));

                                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTempColspan = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th"));

                                    for (int b = curColspanPos; b < nColspanPosProc + colspan; b++)
                                    {
                                        listJobTitle.Add(sJob1 + " " + listThTempColspan[b].Text.Replace("\n", "").Replace("\r", ""));

                                        curColspanPos++;

                                    }

                                    nColspanPosProc += colspan;

                                }
                                else
                                {
                                    listJobTitle.Add(objTh.Text.Replace("\n", "").Replace("\r", ""));

                                }

                            }

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            int nJobPos = 0;

                            foreach (String s in listJobTitle)
                            {
                                setLog("직업종류 > " + s);
                                
                                if (s.Replace("\r", "").Replace("\n", "").Trim().Length>0)
                                    spec.Add(s, tempWebElTbody.FindElements(By.TagName("td"))[nJobPos].Text);

                                nJobPos++;
                            }


                        }
                        else
                        {
                            IWebElement tempWebEl = tempTable.FindElement(By.TagName("thead")).FindElement(By.TagName("tr"));

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            for (int c = 0; c < tempWebEl.FindElements(By.TagName("th")).Count; c++)
                            {
                                if (tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", "").Trim().Length > 0)
                                {
                                    spec.Add(tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", ""), tempWebElTbody.FindElements(By.TagName("td"))[c].Text);
                                }

                                setLog("직업종류 > " + tempWebEl.FindElements(By.TagName("th"))[c].Text);
                            }
                        }

                        specDetail.Add("인력현황", spec);

                        //File.WriteAllText(Application.StartupPath + @"\인력현황_" + sAdminSym + ".json", spec.ToString());
                    }
                }


                if (checkTitle("시설현황", detailDriver))
                {
                    JObject spec = new JObject();
                    spec.Add("관리코드", sAdminSym);
                    spec.Add("최종변경일", getLastUpdate("시설현황", detailDriver));


                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("시설현황 정보"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }

                    int nColspanPosProc = 0;

                    if (tempTable != null)
                    {
                        if (tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr")).Count > 1)
                        {
                            List<String> listJobTitle = new List<string>();

                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTemp = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[0].FindElements(By.TagName("th"));


                            int nColsapnTrCnt = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th")).Count;

                            int curColspanPos = 0;

                            foreach (IWebElement objTh in listThTemp)
                            {

                                if (objTh.GetAttribute("colspan") != null && objTh.GetAttribute("colspan") != "")



                                {

                                    setLog(objTh.Text + " " + objTh.GetAttribute("colspan"));

                                    String sJob1 = objTh.Text;

                                    int colspan = int.Parse(objTh.GetAttribute("colspan"));

                                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTempColspan = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th"));

                                    for (int b = curColspanPos; b < nColspanPosProc + colspan; b++)
                                    {
                                        listJobTitle.Add(sJob1 + " " + listThTempColspan[b].Text.Replace("\n", "").Replace("\r", ""));

                                        curColspanPos++;

                                    }

                                    nColspanPosProc += colspan;

                                }
                                else
                                {
                                    listJobTitle.Add(objTh.Text.Replace("\n", "").Replace("\r", ""));

                                }

                            }

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            int nJobPos = 0;

                            foreach (String s in listJobTitle)
                            {
                                setLog("시설종류 > " + s);

                                if (s.Replace("\r", "").Replace("\n", "").Trim().Length > 0)
                                    spec.Add(s, tempWebElTbody.FindElements(By.TagName("td"))[nJobPos].Text);

                                nJobPos++;
                            }


                        }
                        else
                        {
                            IWebElement tempWebEl = tempTable.FindElement(By.TagName("thead")).FindElement(By.TagName("tr"));

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            for (int c = 0; c < tempWebEl.FindElements(By.TagName("th")).Count; c++)
                            {
                                if (tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", "").Trim().Length > 0)
                                    spec.Add(tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", ""), tempWebElTbody.FindElements(By.TagName("td"))[c].Text);

                                setLog("시설종류 > " + tempWebEl.FindElements(By.TagName("th"))[c].Text);
                            }
                        }

                        specDetail.Add("시설종류", spec);
                        //File.WriteAllText(Application.StartupPath + @"\시설종류_" + sAdminSym + ".json", spec.ToString());
                    }
                }

                if (checkTitle("노인요양시설 내 치매전담실 시설현황", detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate("노인요양시설 내 치매전담실 시설현황", detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));
                    
                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals("노인요양시설 내 치매전담실 시설현황"))
                        {

                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];
                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n","").Replace("\r", "").Trim().Length>0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add("노인요양시설 내 치매전담실 시설현황", specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }

                if (checkTitle("치매전담형 노인요양공동생활가정 시설현황", detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate("치매전담형 노인요양공동생활가정 시설현황", detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals("치매전담형 노인요양공동생활가정 시설현황"))
                        {
                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];

                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n", "").Replace("\r", "").Trim().Length > 0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add("치매전담형 노인요양공동생활가정 시설현황", specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }

                String sTitle = "치매상담실 정원";
                
                if (checkTitle(sTitle, detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate(sTitle, detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals(sTitle))
                        {
                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];

                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n", "").Replace("\r", "").Trim().Length > 0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add(sTitle, specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }

                sTitle = "치매전담형 노인요양공동생활가정 정원";

                if (checkTitle(sTitle, detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate(sTitle, detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals(sTitle))
                        {
                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];

                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n", "").Replace("\r", "").Trim().Length > 0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add(sTitle, specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }

                sTitle = "주야간보호 내 치매전담실 정원";

                if (checkTitle(sTitle, detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate(sTitle, detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals(sTitle))
                        {
                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];

                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n", "").Replace("\r", "").Trim().Length > 0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add(sTitle, specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }



                if (checkTitle("인력현황", detailDriver))
                {
                    JObject spec = new JObject();
                    spec.Add("관리코드", sAdminSym);

                    spec.Add("최종변경일", getLastUpdateSecond("인력현황", detailDriver));


                    

                    listTemp = detailDriver.FindElement(By.Id("apprv1")).FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    int nSeq = 0;
                    
                    foreach (IWebElement temp in listTemp)
                    {
                        //Console.WriteLine(">> " + nSeq.ToString() + " " + temp.GetAttribute("summary"));
                        
                        if (temp.GetAttribute("summary").Contains("인력현황 정보"))
                        {
                            tempTable = temp;
                            break;
                        }
                        
                        //nSeq++;

                    }

                    int nColspanPosProc = 0;

                    if (tempTable != null)
                    {
                        if (tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr")).Count > 1)
                        {
                            List<String> listJobTitle = new List<string>();

                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTemp = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[0].FindElements(By.TagName("th"));


                            int nColsapnTrCnt = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th")).Count;

                            int curColspanPos = 0;

                            foreach (IWebElement objTh in listThTemp)
                            {

                                if (objTh.GetAttribute("colspan") != null && objTh.GetAttribute("colspan") != "")



                                {

                                    setLog(objTh.Text + " " + objTh.GetAttribute("colspan"));

                                    String sJob1 = objTh.Text;

                                    int colspan = int.Parse(objTh.GetAttribute("colspan"));

                                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTempColspan = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th"));

                                    for (int b = curColspanPos; b < nColspanPosProc + colspan; b++)
                                    {
                                        listJobTitle.Add(sJob1 + " " + listThTempColspan[b].Text.Replace("\n", "").Replace("\r", ""));

                                        curColspanPos++;

                                    }

                                    nColspanPosProc += colspan;

                                }
                                else
                                {
                                    listJobTitle.Add(objTh.Text.Replace("\n", "").Replace("\r", ""));

                                }

                            }

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            int nJobPos = 0;

                            foreach (String s in listJobTitle)
                            {
                                setLog("직업종류 > " + s);

                                if (s.Replace("\r", "").Replace("\n", "").Trim().Length > 0)
                                    spec.Add(s, tempWebElTbody.FindElements(By.TagName("td"))[nJobPos].Text);

                                nJobPos++;
                            }


                        }
                        else
                        {
                            IWebElement tempWebEl = tempTable.FindElement(By.TagName("thead")).FindElement(By.TagName("tr"));

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            for (int c = 0; c < tempWebEl.FindElements(By.TagName("th")).Count; c++)
                            {
                                if (tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", "").Trim().Length > 0)
                                {
                                    spec.Add(tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", ""), tempWebElTbody.FindElements(By.TagName("td"))[c].Text);
                                }

                                setLog("직업종류 > " + tempWebEl.FindElements(By.TagName("th"))[c].Text);
                            }
                        }

                        specDetail.Add("인력현황_재가기관", spec);

                        //File.WriteAllText(Application.StartupPath + @"\인력현황_" + sAdminSym + ".json", spec.ToString());
                    }
                }


                sTitle = "방문목욕 차량현황";

                if (checkTitle(sTitle, detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate(sTitle, detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals(sTitle))
                        {
                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];

                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n", "").Replace("\r", "").Trim().Length > 0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add(sTitle, specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }

                if (checkTitle("주야간보호 내 치매전담실 시설현황", detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate("주야간보호 내 치매전담실 시설현황", detailDriver));



                    listTemp = detailDriver.FindElements(By.TagName("h4"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.Text.Trim().Equals("주야간보호 내 치매전담실 시설현황"))
                        {
                            IWebElement parent = temp.GetParent();
                            tempTable = parent.FindElements(By.TagName("table"))[0];

                            break;

                        }
                    }


                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n", "").Replace("\r", "").Trim().Length > 0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add("주야간보호 내 치매전담실 시설현황", specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }


                if (checkTitle("비급여현황", detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate("비급여현황", detailDriver));


                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("비급여현황"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }

                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        if (tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n","").Replace("\r", "").Trim().Length>0)
                                            spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add("비급여현황", specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }


                if (checkTitle("프로그램 운영사항", detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);

                    specRoot.Add("최종변경일", getLastUpdate("프로그램 운영사항", detailDriver));


                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("프로그램 운영사항"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }

                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null && tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\n","").Replace("\r", "").Trim().Length>0)
                                    {
                                        spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text, tempWebEl[c].FindElements(By.TagName("td"))[d].Text);
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add("프로그램_운영사항", specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\프로그램_운영사항" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }

                if (checkTitle("급여비용 가산지급", detailDriver))
                {
                    JObject spec = new JObject();

                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("급여비용 가산지급 정보(급여비용가산 지급기관, 급여제공"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }
                    spec.Add("관리코드", sAdminSym);

                    foreach (IWebElement ss in tempTable.FindElements(By.TagName("th")))
                    {
                        if (ss.Text.Equals("급여비용가산 지급기관"))
                        {
                            if (ss.FindElement(By.XPath("following-sibling::*")).FindElement(By.Id("infoSymYn1")).GetAttribute("checked") != null && ss.FindElement(By.XPath("following-sibling::*")).FindElement(By.Id("infoSymYn1")).GetAttribute("checked")!="")
                            {
                                spec.Add("급여비용가산 지급기관", "예");
                            }
                            else
                            {
                                spec.Add("급여비용가산 지급기관", "아니오");
                            }
                        }

                        if (ss.Text.Equals("급여비용가산 지급기관(공개 동의여부)"))
                        {
                            if (ss.FindElement(By.XPath("following-sibling::*")).FindElement(By.Id("addInfoPbcAgreYn1")).GetAttribute("checked") != null && ss.FindElement(By.XPath("following-sibling::*")).FindElement(By.Id("addInfoPbcAgreYn1")).GetAttribute("checked")!="")
                            {
                                spec.Add("급여비용가산 지급기관(공개 동의여부)", "예");
                            }
                            else
                            {
                                spec.Add("급여비용가산 지급기관(공개 동의여부)", "아니오");
                            }
                        }

                        if (ss.Text.Equals("급여제공 년월"))
                        {
                            spec.Add("급여제공 년월", ss.FindElement(By.XPath("following-sibling::*")).Text);
                        }
                    }


                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("급여비용 가산지급 정보(법정 인력보다 추가하여 운영한경우①),"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }

                    int nColspanPosProc = 0;

                    if (tempTable != null)
                    {
                        if (tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr")).Count > 1)
                        {
                            List<String> listJobTitle = new List<string>();

                            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTemp = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[0].FindElements(By.TagName("th"));


                            int nColsapnTrCnt = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th")).Count;

                            int curColspanPos = 0;

                            foreach (IWebElement objTh in listThTemp)
                            {

                                if (objTh.GetAttribute("colspan") != null && objTh.GetAttribute("colspan") != "")



                                {

                                    setLog(objTh.Text + " " + objTh.GetAttribute("colspan"));

                                    String sJob1 = objTh.Text;

                                    int colspan = int.Parse(objTh.GetAttribute("colspan"));

                                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listThTempColspan = tempTable.FindElement(By.TagName("thead")).FindElements(By.TagName("tr"))[1].FindElements(By.TagName("th"));

                                    for (int b = curColspanPos; b < nColspanPosProc + colspan; b++)
                                    {
                                        listJobTitle.Add(sJob1 + " " + listThTempColspan[b].Text.Replace("\n", "").Replace("\r", ""));

                                        curColspanPos++;

                                    }

                                    nColspanPosProc += colspan;

                                }
                                else
                                {
                                    listJobTitle.Add(objTh.Text.Replace("\n", "").Replace("\r", ""));

                                }

                            }

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            int nJobPos = 0;

                            foreach (String s in listJobTitle)
                            {
                                setLog("직업종류 > " + s);

                                spec.Add(s, tempWebElTbody.FindElements(By.TagName("td"))[nJobPos].Text);

                                nJobPos++;
                            }


                        }
                        else
                        {
                            IWebElement tempWebEl = tempTable.FindElement(By.TagName("thead")).FindElement(By.TagName("tr"));

                            IWebElement tempWebElTbody = tempTable.FindElement(By.TagName("tbody")).FindElement(By.TagName("tr"));

                            for (int c = 0; c < tempWebEl.FindElements(By.TagName("th")).Count; c++)
                            {
                                spec.Add(tempWebEl.FindElements(By.TagName("th"))[c].Text.Replace("\r", "").Replace("\n", ""), tempWebElTbody.FindElements(By.TagName("td"))[c].Text);

                                setLog("직업종류 > " + tempWebEl.FindElements(By.TagName("th"))[c].Text);
                            }
                        }

                        specDetail.Add("급여비용_가산지급", spec);
                        //File.WriteAllText(Application.StartupPath + @"\급여비용_가산지급_" + sAdminSym + ".json", spec.ToString());
                    }


                }



                if (checkTitle("연도별 평가등급", detailDriver))
                {
                    JObject spec = new JObject();
                   
                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("연도별 평가등급"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }
                    spec.Add("관리코드", sAdminSym);

                    if (tempTable != null)
                    {



                        for (int c = 0; c < tempTable.FindElements(By.TagName("tr"))[0].FindElements(By.TagName("td")).Count; c++)
                        {

                            if (tempTable.FindElements(By.TagName("tr"))[0].FindElements(By.TagName("td"))[c] != null)
                            {
                                if (tempTable.FindElements(By.TagName("tr"))[0].FindElements(By.TagName("td"))[c].Text.Trim() != "")
                                {
                                    spec.Add(tempTable.FindElements(By.TagName("tr"))[0].FindElements(By.TagName("td"))[c].Text, tempTable.FindElements(By.TagName("tr"))[1].FindElements(By.TagName("td"))[c].Text);
                                }
                            }
                        }

                        specDetail.Add("연도별_평가등급", spec);
                        //File.WriteAllText(Application.StartupPath + @"\연도별_평가등급_" + sAdminSym + ".json", spec.ToString());
                    }


                }


                if (checkTitle("CCTV 현황", detailDriver))
                {

                    List<JObject> specList = new List<JObject>();


                    JObject specRoot = new JObject();


                    specRoot.Add("관리코드", sAdminSym);


                    listTemp = detailDriver.FindElements(By.TagName("table"));

                    IWebElement tempTable = null;

                    foreach (IWebElement temp in listTemp)
                    {
                        if (temp.GetAttribute("summary").Contains("CCTV 현황"))
                        {
                            tempTable = temp;
                            break;
                        }
                    }

                    if (tempTable != null)
                    {

                        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> tempWebEl = tempTable.FindElements(By.TagName("tr"));

                        JObject spec = new JObject();



                        for (int c = 1; c < tempWebEl.Count; c++)
                        {
                            if (tempWebEl[c] != null)
                            {
                                spec = new JObject();

                                for (int d = 0; d < tempWebEl[c].FindElements(By.TagName("td")).Count; d++)
                                {
                                    if (tempWebEl[c].FindElements(By.TagName("td"))[d] != null)
                                    {
                                        spec.Add(tempWebEl[0].FindElements(By.TagName("th"))[d].Text.Replace("\r", "").Replace("\n", ""), tempWebEl[c].FindElements(By.TagName("td"))[d].Text.Replace("\r", "").Replace("\n", ""));
                                    }
                                }

                                //specList.Add(spec);
                            }

                            specRoot.Add("row_" + c.ToString(), spec);
                        }

                        specDetail.Add("CCTV_현황", specRoot);
                        //File.WriteAllText(Application.StartupPath + @"\CCTV_현황" + sAdminSym + ".json", specRoot.ToString());

                        //foreach (JObject objE in specList)
                        //{
                        //    File.AppendAllText(Application.StartupPath + @"\비급여현황_" + sAdminSym + ".json", objE.ToString());
                        //}

                    }
                }


                //File.WriteAllText(Application.StartupPath + @"\목록_" + sAdminSym + ".json", specDetail.ToString());

                
                Application.DoEvents();

                detailDriver.FindElement(By.Id("fn_close")).Click();

                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
                //driver.SwitchTo().Window(orgHandle);


                if (!Directory.Exists(Application.StartupPath +@"\parsing_data"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\parsing_data");
                }


                File.WriteAllText(Application.StartupPath + @"\lastNo.txt", sRowNo);

                File.WriteAllText(Application.StartupPath + @"\parsing_data\list_" + sAdminSym + "_" + sRowNo + ".json", specDetail.ToString());

                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
                
                //i++;

                nCurThreadCnt--;

                detaildriverService.Dispose();
                detaildriverService = null;

                detailDriver.Close();
                detailDriver.Dispose();
                detailDriver.Quit();
                detailDriver = null;

                //    this.txtLog.AppendText(listHospital[i].FindElements(By.TagName("td"))[0].Text + Environment.NewLine);
            }
            //else
            //{
            //    i++;
            //    procStart(i);
            //}
        }

        int nLastRow = 1;

        private void setLog( String s)
        {
            //this.txtLog.AppendText(s + Environment.NewLine);
        }

        private void setLog2(String s)
        {
            this.txtLog.AppendText( DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " @ "  +  s + Environment.NewLine);
        }

        private Boolean checkTitle(String sTitle, ChromeDriver driver)
        {
            Boolean bCheck = false;

            listTemp = driver.FindElements(By.TagName("h4"));

            foreach (IWebElement temp in listTemp)
            {
                if (temp.Text.Trim().Equals(sTitle.Trim()))
                {
                    bCheck = true;
                    break;
                }

                Thread.Sleep(1);

            }
            return bCheck;
        }


        private String getTextValue(String sTagType, String sTitle, ChromeDriver driver)
        {
            String sResult = String.Empty;

            listTemp = driver.FindElements(By.TagName(sTagType));

            foreach (IWebElement temp in listTemp)
            {
                if (temp.Text.Trim().Equals(sTitle.Trim()))
                {
                    sResult  = temp.FindElement(By.XPath("following-sibling::*")).Text;
                    break;
                    //this.txtLog.AppendText("##" + sTitle + " : " + sResult + Environment.NewLine);
                }

                Thread.Sleep(1);
                
            }

            return sResult.Replace(",","");
        }

        System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> listTemp = null;

        private String getLastUpdate(String s, ChromeDriver driver)
        {
            listTemp = driver.FindElements(By.TagName("h4"));

            foreach (IWebElement temp in listTemp)
            {
                if (temp.Text.Trim().Equals(s.Trim()))
                {
                    if (temp.FindElement(By.XPath("following-sibling::*")).GetAttribute("class").Trim().Equals("last_date"))
                    {
                        s = temp.FindElement(By.XPath("following-sibling::*")).Text;
                    }
                    else
                    {
                        s = "";

                    }

                    break;

                    //this.txtLog.AppendText("##" + temp.Text + " : " + s + Environment.NewLine);
                }
                Thread.Sleep(1);
            }


            return s.Replace(",","");
        }

        private String getLastUpdateSecond(String s, ChromeDriver driver)
        {
            listTemp = driver.FindElements(By.TagName("h4"));

            int i = 0;

            foreach (IWebElement temp in listTemp)
            {
                if (temp.Text.Trim().Equals(s.Trim()) && i == 1)
                {
                    if (temp.FindElement(By.XPath("following-sibling::*")).GetAttribute("class").Trim().Equals("last_date"))
                    {
                        s = temp.FindElement(By.XPath("following-sibling::*")).Text;
                    }
                    else
                    {
                        s = "";

                    }

                    break;

                    //this.txtLog.AppendText("##" + temp.Text + " : " + s + Environment.NewLine);
                }

                Thread.Sleep(1);

                i++;
            }


            return s.Replace(",", "");
        }

        private String removeComma(String s)
        {

            if (s != null && s.Trim() != "")
            {
                return s.Replace(",", "").Replace(Environment.NewLine,"").Replace("상세보기","");
            }
            else
            {
                return "";
            }
        
        }
    }
}

public static class MyExtensions
{
    public static IWebElement GetParent(this IWebElement node)
    {
        return node.FindElement(By.XPath(".."));
    }
}