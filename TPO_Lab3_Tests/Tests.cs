using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TPO_Lab3_Tests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Console.WriteLine("GOVNO");
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AlmsDisplayed()
        {
            var almsQuantity = app.Query(c => c.Marked("ListView").Child()).Length;
            Assert.AreNotEqual(0, almsQuantity);
        }

        [Test]
        public void AlmsSortCorrectlyDisplayed()
        {
            app.Tap(c => c.Marked("SortBtn"));
            app.WaitForElement(c => c.Marked("OverlaySort"));
            Assert.AreEqual(1, app.Query(c => c.Marked("OverlaySort")).Length);
        }

        [Test]
        public void AlmsFilterCorrectlyDisplayed()
        {
            app.Tap(c => c.Marked("FilterBtn"));
            app.WaitForElement(c => c.Marked("OverlayFilter"));
            Assert.AreEqual(1, app.Query(c => c.Marked("OverlayFilter")).Length);
        }

        [Test]
        public void AlmsFilterChooseChangesContent()
        {
            var almsQuantity = app.Query(c => c.Marked("ListView").Child()).Length;

            app.Tap(c => c.Marked("FilterBtn"));
            app.WaitForElement(c => c.Marked("OverlayFilter"));
            app.Tap(c => c.Marked("FurnitureBtn"));
            var afterFilterAlmsQuantity = app.Query(c => c.Marked("ListView").Child()).Length;
            Assert.AreNotEqual(almsQuantity, afterFilterAlmsQuantity);
        }

        [Test]
        public void AlmsSearchWorksCorrectly()
        {
            var almsQuantity = app.Query(c => c.Marked("ListView").Child()).Length;

            app.EnterText(c => c.Marked("SearchBar"), "kreslo");
            app.PressEnter();
            var afterSearchAlmsQuantity = app.Query(c => c.Marked("ListView").Child()).Length;
            Assert.AreNotEqual(afterSearchAlmsQuantity, almsQuantity);
        }

        [Test]
        public void TapOnAlmLeadsToAlmsPage()
        {
            app.Tap(c => c.Marked("ListView").Child(0));
            app.WaitForElement(c => c.Marked("BearerNickname"));
            Assert.AreEqual(1, app.Query(c => c.Marked("BearerNickname")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Name")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Image")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Description")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Phone")).Length);
        }

        [Test]
        public void TapOnPhoneChangesPhone()
        {
            app.Tap(c => c.Marked("ListView").Child(0));
            app.WaitForElement(c => c.Marked("BearerNickname"));
            var phone = app.Query(c => c.Marked("Phone"))[0].Text;
            app.Tap(c => c.Marked("Phone"));
            var changedPhone = app.Query(c => c.Marked("Phone"))[0].Text;
            Assert.AreNotEqual(phone, changedPhone);
        }

        [Test]
        public void TapOnBearerNicknameLeadsToBearerPage()
        {
            app.Tap(c => c.Marked("ListView").Child(0));
            app.WaitForElement(c => c.Marked("BearerNickname"));
            app.Tap(c => c.Marked("BearerNickname"));
            app.WaitForElement(c => c.Marked("ListView"));
            Assert.AreEqual(1, app.Query(c => c.Marked("ListView")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Name")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Phone")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("ListView")).Length);
        }


        [Test]
        public void SwipeLeadsToBearersPage()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            Assert.AreEqual(1, app.Query(c => c.Marked("SignInBtn")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("SignUpBtn")).Length);
        }

        [Test]
        public void TapOnSignInLeadsToSignForm()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            Assert.AreEqual(1, app.Query(c => c.Marked("SignNickname")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("SignPassword")).Length); 
            Assert.AreEqual(1, app.Query(c => c.Marked("SignBtn")).Length);

        }

        [Test]
        public void TapOnSignUpLeadsToRegisterForm()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignUpBtn"));
            app.WaitForElement(c => c.Marked("OverlayRegister"));
            Assert.AreEqual(1, app.Query(c => c.Marked("RegNickname")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("RegPassword")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("RegPasswordConfirmation")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("RegPhone")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("RegBtn")).Length);
        }

        //      app.EnterText(c => c.Marked("SearchBar"), "kreslo");
        //      app.PressEnter();
        [Test]
        public void SignInIncorrectCredentialsShowsErrorMessage()
        { 
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "NEbatinpass");
            app.Tap(c=>c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("SignError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("SignError")).Length);
        }

        [Test]
        public void CorrectSignInLeadsToBearerPage()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "batinpass");
            app.Tap(c=>c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("Name"));
            Assert.AreEqual(1, app.Query(c => c.Marked("Name")).Length);
        }

        [Test]
        public void RegisterAlreadyTakenNicknameShowsErrorMessage()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignUpBtn"));
            app.WaitForElement(c => c.Marked("OverlayRegister"));
            app.EnterText(c => c.Marked("RegNickname"), "batya");
            app.Tap(c => c.Marked("RegBtn"));
            app.WaitForElement(c => c.Marked("RegNicknameError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("RegNicknameError")).Length);
        }

        [Test]
        public void RegisterInequalPasswordsShowsErrorMessage()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignUpBtn"));
            app.WaitForElement(c => c.Marked("OverlayRegister"));
            app.EnterText(c => c.Marked("RegNickname"), "batyanyatoregister");
            app.EnterText(c => c.Marked("RegPassword"), "batyapassword");
            app.EnterText(c => c.Marked("RegPasswordConfirmation"), "batya1");
            app.Tap(c => c.Marked("RegBtn"));
            app.WaitForElement(c => c.Marked("RegPasswordError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("RegPasswordError")).Length);
        }

        [Test]
        public void RegisterIncorrectPhoneShowsErrorMessage()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignUpBtn"));
            app.WaitForElement(c => c.Marked("OverlayRegister"));
            app.EnterText(c => c.Marked("RegNickname"), "batyanyatoregister");
            app.EnterText(c => c.Marked("RegPassword"), "batyapassword");
            app.EnterText(c => c.Marked("RegPasswordConfirmation"), "batyapassword");
            app.EnterText(c => c.Marked("RegPhone"), "1/2/5/4");
            app.Tap(c => c.Marked("RegBtn"));
            app.WaitForElement(c => c.Marked("RegPhoneError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("RegPhoneError")).Length);
        }


        [Test]
        public void TapOnAddAlmsgivingLeadsToAddAlmsgivingPage()
        { 
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "batinpass");
            app.Tap(c => c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("AddBtn"));
            app.Tap(c => c.Marked("AddBtn"));
            app.WaitForElement(c => c.Marked("Name"));
            Assert.AreEqual(1, app.Query(c => c.Marked("Name")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Description")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("Picker")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("PhotoBtn")).Length);
            Assert.AreEqual(1, app.Query(c => c.Marked("SubmitBtn")).Length);
        }

        [Test]
        public void AddAlmsgivingPageEmptyNameShowsError()
        {

            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "batinpass");
            app.Tap(c => c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("AddBtn"));
            app.Tap(c => c.Marked("AddBtn"));
            app.WaitForElement(c => c.Marked("Name"));
            app.Tap(c => c.Marked("SubmitBtn"));
            app.WaitForElement(c => c.Marked("NameError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("NameError")).Length);
        }

        [Test]
        public void AddAlmsgivingPageEmptyDescriptionShowsError()
        { 
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "batinpass");
            app.Tap(c => c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("AddBtn"));
            app.Tap(c => c.Marked("AddBtn"));
            app.WaitForElement(c => c.Marked("Name"));
            app.EnterText(c => c.Marked("Name"), "batin stul");
            app.Tap(c => c.Marked("SubmitBtn"));
            app.WaitForElement(c => c.Marked("DescriptionError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("DescriptionError")).Length);
        }

        [Test]
        public void AddAlmsgivingPageEmptyPhotoShowsError()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "batinpass");
            app.Tap(c => c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("AddBtn"));
            app.Tap(c => c.Marked("AddBtn"));
            app.WaitForElement(c => c.Marked("Name"));
            app.EnterText(c => c.Marked("Name"), "batin stul");
            app.EnterText(c => c.Marked("Description"), "Prosto batin stul");
            app.Tap(c => c.Marked("SubmitBtn"));
            app.WaitForElement(c => c.Marked("PhotoError"));
            Assert.AreEqual(1, app.Query(c => c.Marked("PhotoError")).Length);
        }

        [Test]
        public void TapOnDeleteBearersAlmsgivingShowsOverlay()
        {
            app.SwipeRightToLeft();
            app.WaitForElement(c => c.Marked("OverlayWelcome"));
            app.Tap(c => c.Marked("SignInBtn"));
            app.WaitForElement(c => c.Marked("OverlaySign"));
            app.EnterText(c => c.Marked("SignNickname"), "batya");
            app.EnterText(c => c.Marked("SignPassword"), "batinpass");
            app.Tap(c => c.Marked("SignBtn"));
            app.WaitForElement(c => c.Marked("ListView"));
            app.Tap(c => c.Marked("ListView").Child(0));
            app.WaitForElement(c => c.Marked("Image"));
            app.Tap(c => c.Marked("DeleteBtn"));
            app.WaitForElement(c => c.Marked("OverlayDelete"));
            Assert.AreEqual(1, app.Query(c => c.Marked("OverlayDelete")).Length);
        }

        [Test]
        public void REPL()
        {
            app.Tap(c => c.Marked("ListView").Child(0));
            app.Repl();
        }
    }
}