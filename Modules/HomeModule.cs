using Nancy;
using PreviousPlacesNS.Objects;
using System.Collections.Generic;
using System.Web;
using System;

namespace PreviousPlacesNS
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        Console.WriteLine("Homepage");
        return View["placeList.cshtml", Place.GetAll()];
      };
      Get["/city/{id}"] = x => {
          Place place = Place.GetPlaceById(x.id);
          Console.WriteLine("Viewing City By Id: " +place.GetCity());
          return View["viewPlace.cshtml", place];
      };
      Get["/clearAll"] = _ => {
        Place.DestroyAll();
        return View["redirect.cshtml"];
      };
      Get["/edit/{id}"] = x => {
        return View["editPlace.cshtml", Place.GetPlaceById(x.id)];
      };
      Post["/addPlace"] = _ => {
        Console.WriteLine("Adding a Place");
        Dictionary<string,string> formData = new Dictionary<string,string>(){};
        string fieldsString = "city description stayLength picture";
        string[] fields = fieldsString.Split(' ');
        foreach(string field in fields) {
          formData.Add(field, Request.Form[field]);
        }

        Place place = new Place(formData[fields[0]], formData[fields[1]], formData[fields[2]], formData[fields[3]] );
        Console.WriteLine("Added Place: " + place.GetId() + " " + place.GetCity());
        return View["redirect.cshtml", "/"];
      };
      Post["/savePlace"] = _ =>{

        int id = int.Parse(Request.Form["id"]);
        Place place = Place.GetPlaceById(id);

        string city = Request.Form["city"];
        place.SetCity(city);
        string description = Request.Form["description"];
        place.SetDescription(description);
        string stayLength = Request.Form["stayLength"];
        place.SetStayLength(stayLength);
        string picture = Request.Form["picture"];
        place.SetPicture(picture);

        return View["redirect.cshtml", "/city/" + id];
      };
    }
  }
}
