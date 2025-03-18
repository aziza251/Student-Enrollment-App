namespace mobile
{
    public partial class enroll : ContentPage
    {
        private Models.StudentClass selectedStudent;
        private Models.CourseClass selectedCourse;
        private Models.EnrollClass selectedEnroll;

        public enroll()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Load the student and course lists when the page appears
            StudentList.ItemsSource = App.DBTrans.GetAllStudents();
            CourseList.ItemsSource = App.DBTrans.GetAllCourses();
        }

        private async void add3_Clicked(object sender, EventArgs e)
        {
            if (selectedStudent != null && selectedCourse != null)
            {
                bool success = App.DBTrans.Add(new Models.EnrollClass
                {
                    Stu_ID = selectedStudent.ID,
                    Stu_Name = selectedStudent.Name,
                    course_code = selectedCourse.course_code
                });

                if (success)
                {
                    selectedStudent = null;
                    selectedCourse = null;
                    EnrollList.ItemsSource = App.DBTrans.GetEnrollList();
                }
                else
                {
                    await DisplayAlert("Error", "Enrollment could not be added", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please select a student and a course", "OK");
            }
           
        }

        private void show3_Clicked(object sender, EventArgs e)
        {
            EnrollList.ItemsSource = App.DBTrans.GetEnrollList();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (selectedEnroll != null)
            {
                App.DBTrans.DeleteEnrollment(selectedEnroll.Stu_ID, selectedEnroll.course_code);
                EnrollList.ItemsSource = App.DBTrans.GetEnrollList();
                selectedEnroll = null;
                delete.IsEnabled = false;
            }
        }

        private void EnrollList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedEnroll = (Models.EnrollClass)e.Item;
            delete.IsEnabled = selectedEnroll != null;
        }

        private void StudentList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedStudent = (Models.StudentClass)e.Item;
        }

        private void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedCourse = (Models.CourseClass)e.Item;
        }
    }
}
