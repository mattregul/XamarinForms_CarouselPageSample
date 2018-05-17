using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace XamarinForms_CarouselPageSample
{
	public class TestContentPage : CarouselPage
	{
		// global string to hold our Table of Contents details
		string pageInfo;

		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinForms_CarouselPageSample.TestContentPage"/> class.
		/// </summary>
		public TestContentPage ()
		{

			// Dictionary to hold each of the titles and colors for our pages
			var PageAndColors = new Dictionary<string, Color> ();
			PageAndColors.Add ("Page 0 - Red", Color.Red);
			PageAndColors.Add ("Page 1 - Green", Color.Green);
			PageAndColors.Add ("Page 2 - Blue", Color.Blue);
			PageAndColors.Add ("Page 3 - Purple", Color.Purple);
			PageAndColors.Add ("Page 4 - Yellow", Color.Yellow);
			PageAndColors.Add ("Page 5 - Pink", Color.Pink);
			PageAndColors.Add ("Page 6 - Olive", Color.Olive);
			PageAndColors.Add ("Page 7 - Teal", Color.Teal);
			PageAndColors.Add ("Page 8 - Maroon", Color.Maroon);


			// Make a ToC for each of the pages, we'll display this in a labe, on each ContentPage.
			//	== Example =====================
			//	Index #			Title
			//	0				Page 0 - Red
			//	1				Page 1 - Green
			//	2				Page 2 - Blue
			//	3				Page 3 - Purple
			//	4				Page 4 - Yellow
			//	5				Page 5 - Pink
			//	6				Page 6 - Olive
			//	7				Page 7 - Teal
			//	8				Page 8 - Maroon
			int i = 0;
			pageInfo = "Index #\t\t\tTitle\n";
			foreach (var page in PageAndColors) {
				pageInfo += " " + i + "\t\t\t\t" + page.Key + "\n";
				i++;
			}


			// Create a ContentPage for each of the items in PageAndColors
			foreach (var page in PageAndColors) {
				Children.Add (CreateContentPage (page.Key /*Title*/, page.Value /*Color*/));
			}

		}


		/// <summary>
		/// Creates a content page
		/// </summary>
		/// <returns>a new content page.</returns>
		/// <param name="pageTitle">Page Title</param>
		/// <param name="tocBackgroundColor">Table of Contents label background color.</param>
		public ContentPage CreateContentPage (string pageTitle, Color tocBackgroundColor)
		{
			
			var btnGoPage3 = new Button () { Text = "Go to Page 3 (Purple)" };
			btnGoPage3.Clicked += ButtonClicked_GoToPage3;


			var btnGoPage5 = new Button () { Text = "Go to Page 5 (Pink)" };
			btnGoPage5.Clicked += ButtonClicked_GoToPage5;


			var btnGoLastPage = new Button () { Text = "Go to Last Page (Maroon)" };
			btnGoLastPage.Clicked += ButtonClicked_GoToLastPage;


			var btnGoToFirstPage = new Button () { Text = "Back to the first page (index 0)" };
			btnGoToFirstPage.Clicked += ButtonClicked_GoToFirstPage;


			return new ContentPage {
				Title = pageTitle,
				Padding = new Thickness (0, Device.OnPlatform (40, 40, 0), 0, 0),
				Content = new StackLayout {
					Padding = new Thickness (20, 20),
					Children = {
						new Label {
							Text = pageTitle,
							FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
							HorizontalOptions = LayoutOptions.Center
						},
						new Label {
							BackgroundColor = tocBackgroundColor,
							WidthRequest = 250,
							TextColor = Color.Black,
							Text = pageInfo,
							FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
							VerticalTextAlignment = TextAlignment.Center
						},
						btnGoToFirstPage,
						btnGoPage3,
						btnGoPage5,
						btnGoLastPage,
					}
				}
			};

		}


		/// <summary>
		/// Navigate to Page 3
		/// </summary>
		void ButtonClicked_GoToPage3 (object sender, EventArgs e)
		{
			Debug.WriteLine ("Nav to page 3");
			this.SelectedItem = Children.ElementAt<ContentPage> (3);
		}


		/// <summary>
		/// Navigate to Page 5
		/// </summary>
		void ButtonClicked_GoToPage5 (object sender, EventArgs e)
		{
			Debug.WriteLine ("Nav to page 5");
			this.SelectedItem = Children.ElementAt<ContentPage> (5);
		}


		/// <summary>
		/// Navigate to the last page.
		/// </summary>
		void ButtonClicked_GoToLastPage (object sender, EventArgs e)
		{
			Debug.WriteLine ("Nav to last page");
			// CarouselPage is 0-index based, so... You'll need count-1
			this.SelectedItem = Children.ElementAt<ContentPage> (Children.Count () - 1);
		}


		/// <summary>
		/// Navigate to the first page.
		/// </summary>
		void ButtonClicked_GoToFirstPage (object sender, EventArgs e)
		{
			Debug.WriteLine ("Nav to first page");
			this.SelectedItem = Children.ElementAt<ContentPage> (0);
		}



	}
}