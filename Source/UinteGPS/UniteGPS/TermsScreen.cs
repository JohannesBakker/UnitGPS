using System;
using Xamarin.Forms;

namespace UniteGPS
{
	public class TermsScreen : ContentPage
	{
		public TermsScreen ()
		{
				this.BackgroundColor = Color.White;

			var emptylabel = new Label {
				BackgroundColor = Color.White,
				HeightRequest = 15,
			};
			var imgtop = new Image {
				Source = "Images/UinteGps_Title.png",
				WidthRequest = 80,
				HeightRequest = 80,
			};
			var lab1 = new Label {
				Text = "UniteGPS Terms of Service",
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.StartAndExpand,
			};
			var lab2 = new Label {
				Text = "As of January 1,2014",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab3 = new Label {
				Text = "Thank you for using UniteGPS Solutions!",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab4 = new Label {
				Text = "UniteGPS Solutions are provided by UniteGPS, LLC, 31 East Grand Avenue,suite 44, Old Orchard Beach,Main 04064.",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab5 = new Label {
				Text = "By using UniteGPS solutions,you are agreeing to these terms.Please read them carefully.",
				HorizontalOptions = LayoutOptions.Start,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab6 = new Label {
				Text = "Using UniteGPS Solutions",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab7 = new Label {
				Text = "You must follow any policies made available to you within each Solution.",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab8 = new Label {
				Text = "Don't misuse UniteGPS Solution.For example, don't interfere with UniteGPS Solutions or try to access them using a method other than the interface and the instructions that we provide." +
				"You may use UniteGPS Solutions only as permitted by law, including applicable export and re-export control laws and regulations. " +
				"We may suspend or stop providing UniteGPS Solutions to you if you do not comply with UniteGPS terms or policies or if we are investigating suspected misconduct.",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab9 = new Label {
				Text = "Using UniteGPS Solutions does not give you ownership of any intellectual property rights in UniteGPS Solutions " +
				"or the content you access. You may not use content from UniteGPS Solutions unless you obtain permission from its owner or " +
				"are otherwise permitted" +
				"by law. These terms do not grant you the right to use any branding or logos used in" +
				"UniteGPS Solutions. Don’t remove, obscure, or alter any legal notices displayed in or along with UniteGPS Solutions.",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab10 = new Label {
				Text = "Some UniteGPS Solutions display some content that is not ours." +
				"This content is the sole responsibility of the entity that makes it available. We may review content to determine whether it is illegal or violates UniteGPS policies, and we may remove or refuse to display " +
				"content that we reasonably believe violates UniteGPS policies or the law." +
				"But that does not necessarily mean that we review content,so please don’t assume that we do.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab11 = new Label {
				Text = "In connection with your use of UniteGPS Solutions, we may send you service" +
				" announcements, administrative messages, and other information." +
				"You may opt out of some of those communications.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab12 = new Label {
				Text = "Some of UniteGPS Solutions are available on mobile devices." +
				"Do not use such Solutions in a way that distracts you and prevents" +
				"you from obeying traffic or safety laws.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab13 = new Label {
				Text = "GPS Reliability & Accuracy",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab14 = new Label {
				Text = "You may need a UniteGPS Account in order to use some UniteGPS Solutions." +
				"You may create your own UniteGPS Account, or your UniteGPS Account may be assigned to you by an administrator, such as your employer or educational institution. " +
				"If you are using a UniteGPS Account assigned to you by an administrator, different or additional terms may apply and your administrator" +
				"may be able to access or disable your account. To protect your UniteGPS Account, keep your password confidential. You are responsible for the" +
				"activity that happens on or through your UniteGPS Account. " +
				"Try not to reuse your UniteGPS Account password on third-party applications." +
				" If you learn of any unauthorized use of your UniteGPS password or Account, change your password immediately.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab15 = new Label {
				Text = "Your UniteGPS Account",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab16 = new Label {
				Text = "You may need a UniteGPS Account in order to use some UniteGPS Solutions. You may" +
				"create your own UniteGPS Account, or your UniteGPS Account may be assigned" +
				"to you by an administrator, such as your employer or educational institution." +
				"If you are using a UniteGPS Account assigned to you by an administrator," +
				"different or additional terms may apply and your administrator may be able" +
				"to access or disable your account.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab17 = new Label {
				Text = "To protect your UniteGPS Account, keep your password confidential." +
				"You are responsible for the activity that happens on or through your UniteGPS" +
				"Account. Try not to reuse your UniteGPS Account password on third-party" +
				"applications. If you learn of any unauthorized use of your UniteGPS password" +
				"or Account, change your password immediately.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab18 = new Label {
				Text = "Privacy and Copyright Protection",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab19 = new Label {
				Text = "UniteGPS privacy policy explains how we treat your personal data and protect" +
				"your privacy when you use UniteGPS Solutions. By using UniteGPS Solutions," +
				"you agree that UniteGPS can use such data in accordance with UniteGPS privacy" +
				"policies.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab20 = new Label {
				Text = "UniteGPS responds to notices of alleged copyright infringement and terminate" +
				"accounts of repeat infringers according to the process set out in the U.S." +
				"Digital Millennium Copyright Act.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab21 = new Label {
				Text = "We provide information to help copyright holders manage their intellectual" +
				"property online. If you think somebody is violating your copyrights and want to" +
				"notify us by calling 207-591-7777",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab22 = new Label {
				Text = "Your Content in UniteGPS Solutions",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab23 = new Label {
				Text = "Some UniteGPS Solutions allow you to submit content. You retain ownership of" +
				"any intellectual property rights that you hold in that content. What belongs" +
				"to you stays yours.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab24 = new Label {
				Text = "When you upload or otherwise submit content to a UniteGPS Solution, you give" +
				"UniteGPS (and those we work with) a worldwide license to use, host, store," +
				"reproduce, modify, create derivative works (such as those resulting from" +
				"translations, adaptations or other changes we make so that your content" +
				"works better with UniteGPS Solutions), communicate, publish, publicly" +
				"perform, publicly display and distribute such content. The rights you grant" +
				"in this license are for the limited purpose of operating, promoting, and" +
				"improving UniteGPS Solutions, and to develop new ones. This license" +
				"continues even if you stop using UniteGPS Solutions. Some Solutions may" +
				"offer you ways to access and remove content that has been provided to that" +
				"Service. Also, in some of UniteGPS Solutions, there are terms or settings" +
				"that narrow the scope of UniteGPS use of the content submitted in those" +
				"Solutions. Make sure you have the necessary rights to grant us this license" +
				"for any content that you submit to UniteGPS Solutions.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
				var lab25 = new Label {
					Text = "If you have a UniteGPS Account, we may display your Profile name, Profile" +
					"photo, and actions you take on UniteGPS or on third-party applications" +
					"connected to your UniteGPS Account. UniteGPS will respect the choices you" +
					"make to limit sharing or visibility settings in your UniteGPS Account.",
					BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
					TextColor = Color.Black,
			};
			var lab26 = new Label {
				Text = "You can find more information about how UniteGPS uses and stores content in" +
				"the privacy policy or additional terms for particular Solutions. If you" +
				"submit feedback or suggestions about UniteGPS Solutions, we may use your" +
				"feedback or suggestions without obligation to you.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab27 = new Label {
				Text = "About Software in UniteGPS Solutions",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab28 = new Label {
				Text = "When a Service requires or includes downloadable software, this software may" +
				"update automatically on your device once a new version or feature is" +
				"available. Some Solutions may let you adjust your automatic update settings.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab29 = new Label {
				Text = "UniteGPS gives you a personal, worldwide, royalty-free, non-assignable and" +
				"non-exclusive license to use the software provided to you by UniteGPS as" +
				"part of our Solutions. This license is for the sole purpose of enabling you" +
				"to use and enjoy the benefit of the Solutions as provided by UniteGPS, in" +
				"the manner permitted by these terms. You may not copy, modify, distribute," +
				"sell, or lease any part of UniteGPS Solutions or included software, nor may" +
				"you reverse engineer or attempt to extract the source code of that software," +
				"unless laws prohibit those restrictions or you have written permission from UniteGPS.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab30 = new Label {
				Text = "Open source software is important to UniteGPS. Some software used in UniteGPS" +
				"Solutions may be offered under an open source license that we will make" +
				"available to you. There may be provisions in the open source license that" +
				"expressly override some of these terms.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab31 = new Label {
				Text = "Modifying and Terminating UniteGPS Solutions",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab32 = new Label {
				Text = "We are constantly changing and improving UniteGPS Solutions. We may add or" +
				"remove functionalities or features, and we may suspend or stop a Service altogether.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab33 = new Label {
				Text = "You can stop using UniteGPS Solutions at any time, although we’ll be sorry" +
				"to see you go. UniteGPS may also stop providing Solutions to you, or add or" +
				"create new limits to UniteGPS Solutions at any time.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab34 = new Label {
				Text = "We believe that you own your data and preserving your access to such data is" +
				"important. If we discontinue a Service, where reasonably possible, we will" +
				"give you reasonable advance notice and a chance to get information out of" +
				"that Service.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab35 = new Label {
				Text = "UniteGPS Warranties and Disclaimers",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab36 = new Label {
				Text = "We provide UniteGPS Solutions using a commercially reasonable level of skill" +
				"and care and we hope that you will enjoy using them. But there are certain" +
				"things that we don’t promise about UniteGPS Solutions.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab37 = new Label {
				Text = "OTHER THAN AS EXPRESSLY SET OUT IN THESE TERMS OR ADDITIONAL TERMS, NEITHER" +
				"UNITEGPS NOR ITS SUPPLIERS OR DISTRIBUTORS MAKE ANY SPECIFIC PROMISES ABOUT" +
				"THE SOLUTIONS. FOR EXAMPLE, WE DON’T MAKE ANY COMMITMENTS ABOUT THE CONTENT" +
				"WITHIN THE SOLUTIONS, THE SPECIFIC FUNCTIONS OF THE SOLUTIONS, OR THEIR" +
				"RELIABILITY, AVAILABILITY, OR ABILITY TO MEET YOUR NEEDS. WE PROVIDE THE" +
				"SOLUTIONS “AS IS”.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab38 = new Label {
				Text = "SOME JURISDICTIONS PROVIDE FOR CERTAIN WARRANTIES, LIKE THE IMPLIED WARRANTY" +
				"OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT." +
				"TO THE EXTENT PERMITTED BY LAW, WE EXCLUDE ALL WARRANTIES.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab39 = new Label {
				Text = "Liability for UniteGPS Solutions",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab40 = new Label {
				Text = "WHEN PERMITTED BY LAW, UNITEGPS, AND UNITEGPS’S SUPPLIERS AND DISTRIBUTORS," +
				"WILL NOT BE RESPONSIBLE FOR LOST PROFITS, REVENUES, OR DATA, FINANCIAL" +
				"LOSSES OR INDIRECT, SPECIAL, CONSEQUENTIAL, EXEMPLARY, OR PUNITIVE DAMAGES.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab41 = new Label {
				Text = "TO THE EXTENT PERMITTED BY LAW, THE TOTAL LIABILITY OF UNITEGPS, AND ITS" +
				"SUPPLIERS AND DISTRIBUTORS, FOR ANY CLAIMS UNDER THESE TERMS, INCLUDING FOR" +
				"ANY IMPLIED WARRANTIES, IS LIMITED TO THE AMOUNT YOU PAID US TO USE THE" +
				"SOLUTIONS (OR, IF WE CHOOSE, TO SUPPLYING YOU THE SOLUTIONS AGAIN).",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab42 = new Label {
				Text = "IN ALL CASES, UNITEGPS, AND ITS SUPPLIERS AND DISTRIBUTORS, WILL NOT BE" +
				"LIABLE FOR ANY LOSS OR DAMAGE THAT IS NOT REASONABLY FORESEEABLE.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab43 = new Label {
				Text = "Business uses of UniteGPS Solutions",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab44 = new Label {
				Text = "If you are using UniteGPS a Solution on behalf of a business, that business" +
				"accepts these terms. It will hold harmless and indemnify UniteGPS and its" +
				"affiliates, officers, agents, and employees from any claim, suit or action" +
				"arising from or related to the use of the Solutions or violation of these" +
				"terms, including any liability or expense arising from claims, losses," +
				"damages, suits, judgments, litigation costs and attorneys’ fees.",
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var lab45 = new Label {
				Text = "About these Terms",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab46 = new Label {
				Text = "We may modify these terms or any additional terms that apply to a Service to," +
				"for example, reflect changes to the law or changes to UniteGPS Solutions." +
				"You should look at the terms regularly. We’ll post notice of modifications" +
				"to these terms on this page. We’ll post notice of modified additional terms" +
				"in the applicable Service. Changes will not apply retroactively and will" +
				"become effective no sooner than fourteen days after they are posted." +
				"However, changes addressing new functions for a Service or changes made for" +
				"legal reasons will be effective immediately. If you do not agree to the" +
				"modified terms for a Service, you should discontinue your use of that Service.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab47 = new Label {
				Text = "If there is a conflict between these terms and the additional terms, the" +
				"additional terms will control for that conflict.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab48 = new Label {
				Text = "These terms control the relationship between UniteGPS and you. They do not" +
				"create any third party beneficiary rights.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab49 = new Label {
				Text = "If you do not comply with these terms, and we don’t take action right away," +
				"this doesn’t mean that we are giving up any rights that we may have (such" +
				"as taking action in the future).",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab50 = new Label {
				Text = "If it turns out that a particular term is not enforceable, this will not affect any other terms.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};
			var lab51 = new Label {
				Text = "The laws of California, U.S.A., excluding California’s conflict of laws" +
				"rules, will apply to any disputes arising out of or relating to these terms" +
				"or the Solutions. All claims arising out of or relating to these terms or" +
				"the Solutions will be litigated exclusively in the federal or state courts" +
				"of York County, Maine, USA, and you and UniteGPS consent to personal" +
				"jurisdiction in those courts.",
				BackgroundColor = Color.White,
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
			};
			var lab52 = new Label {
				Text = "For information about how to contact UniteGPS, please visit the UniteGPS contact page.",
				BackgroundColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
				TextColor = Color.Black,
			};

			var terms = new StackLayout {
				Spacing = 0,
				Children = { lab3, lab4 }
			};
			var Termspart = new StackLayout {
				Spacing = 10,
				Padding = new Thickness (20, 0, 10, 0),
				Children = {lab1, lab2, terms, lab5, lab6, lab7, lab8, lab9, lab10, lab11, lab12, lab13, lab14
					, lab15, lab16, lab17, lab18, lab19, lab20, lab21, lab22, lab23, lab24, lab25, lab26, lab27, lab28, lab29, lab30
					, lab31, lab32, lab33, lab34, lab35, lab36, lab37, lab38, lab39, lab40, lab41, lab42, lab43, lab44, lab45, lab46,
					lab47, lab48, lab49, lab50, lab51, lab52,
				},
			};
			var bntaccept = new Button {
				Text = "Accept and Continue",
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Button)),
				TextColor = Color.White,
				BackgroundColor = Color.Green,
			};

			bntaccept.Clicked += (sender, e) => {
				var networkConnection = DependencyService.Get<INetworkConnection> ();
				networkConnection.CheckNetworkConnection ();
				if (networkConnection.IsConnected) 
				{
					Devices.Storage.Set ("flag", "0");
					Navigation.PushModalAsync (new LoginScreen (), true);
				}
				else 
				{
					DisplayAlert ("UniteGPS", "Please check your network and try again ", null, "OK");
				}
			};

			var scrollView = new ScrollView {
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = ScrollOrientation.Vertical,
				HeightRequest = 1000,

				Content = new StackLayout {
					Spacing = 25,
					Orientation = StackOrientation.Vertical,
					Children = { imgtop, Termspart, bntaccept }
				}
			};
			Content = new StackLayout {
				Children = { emptylabel, scrollView }
			};
		}
	}
}