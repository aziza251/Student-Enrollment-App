namespace mobile;

public partial class course : ContentPage
{
    private Models.CourseClass selectedCourse;
    public course()
	{
		InitializeComponent();
	}

    private void show2_Clicked(object sender, EventArgs e)
    {
        CourseList.ItemsSource = App.DBTrans.GetAllCourses();

    }

    private void add2_Clicked(object sender, EventArgs e)
    {
        App.DBTrans.Add(new Models.CourseClass
        {
           
            course_code = code.Text,
            course_name = namee.Text

        });
        CourseList.ItemsSource = App.DBTrans.GetAllCourses();

    }
    private void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
    {

        selectedCourse = (Models.CourseClass)e.Item;
        delete.IsEnabled = selectedCourse != null;


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (selectedCourse != null)
        {
            App.DBTrans.Deletee(selectedCourse.course_Id);
           CourseList.ItemsSource = App.DBTrans.GetAllCourses();
            selectedCourse = null;
            delete.IsEnabled = false;
        }
    }

    
}