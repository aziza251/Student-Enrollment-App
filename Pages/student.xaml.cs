namespace mobile;

public partial class student : ContentPage


{
    private Models.StudentClass selectedStudent;
    public student()
	{
		InitializeComponent();

       
	}


    private void add_Clicked(object sender, EventArgs e)
    {
        App.DBTrans.Add(new Models.StudentClass
        {
            Name = name.Text,
            Department = dept.Text
        });

    
}

    private void show_Clicked(object sender, EventArgs e)
    {
        StudentList.ItemsSource=App.DBTrans.GetAllStudents();

    }

    private void StudentList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        selectedStudent = (Models.StudentClass)e.Item;
        delete.IsEnabled = selectedStudent != null;
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (selectedStudent != null)
        {
            App.DBTrans.Delete(selectedStudent.ID);
            StudentList.ItemsSource = App.DBTrans.GetAllStudents();
            selectedStudent = null;
            delete.IsEnabled = false;
        }
    }

   
}