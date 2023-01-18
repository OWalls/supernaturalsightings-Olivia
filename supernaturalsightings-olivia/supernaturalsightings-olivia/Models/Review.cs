namespace supernaturalsightings_olivia.Models;

public class Review
{
    public string Username { get; set; }
    public string Description { get; set; }
    public int ReviewId { get; set; }
    public ReviewCategory Category { get; set; }
    public int Id { get; set; }
    public Review(string userName, string description)
    {
        Username = userName;
        Description = description;

    }
    public Review()
    {

    }

    public override string ToString()
    {
        return Username;
    }

    public override bool Equals(object? obj)
    {
        return obj is Review @review &&
            Id == review.Id;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
//@*@*
//For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//*@
//@{
//}
//@model List<supernaturalsightings_olivia.Models.ReviewCategory>

//    <h1>All Review Categories</h1>

//    @if (Model.Count == 0)
//{
//        < p > No Review Categories yet </ p >
//    }
//    else
//{
//        < table class= "table" >
//            < tr >
//                < th > Category Name </ th >
//            </ tr >
//            @foreach(ReviewCategory category in Model){
//                < tr >
//                    < td > @category.ReviewType </ td >
//                </ tr >
//            }
//        </ table >
//    }*@

//@*@*
//    For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//*@
//@{
//}
//@model supernaturalsightings_olivia.ViewModels.AddReviewCategoryViewModel

//<h1>Add Creepy Category</h1> @* drop down options for alien/big foot/ghost*@

//<form asp-controller= "ReviewCategory" asp-action= "ProcessCreateReviewCategoryForm" method= "post" >
//    < div class= "form-group" >
//        < label asp -for= "Category" ></ label >
//        < input asp -for= "Category" />
//        < span asp - validation -for= "Category" ></ span >
//    </ div >
//    < input type = "submit" value = "Add Category" />
//</ form >
//*@
////}
