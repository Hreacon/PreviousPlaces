using System.Collections.Generic;

namespace PreviousPlacesNS.Objects
{
  public class Place
  {
    private string _city;
    private string _description;
    private string _stayLength;
    private string _picture;
    private int _id;
    private static List<Place> _placeList = new List<Place> {};

    public Place (string city, string description, string stayLength, string picture)
    {
      this.SetCity(city);
      this.SetDescription(description);
      this.SetStayLength(stayLength);
      this.SetPicture(picture);

      _id = _placeList.Count;
      _placeList.Add(this);
    }
    //Getter
    public string GetCity()
    {
      return _city;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetDescription()
    {
      return _description;
    }
    public string GetStayLength()
    {
      return _stayLength;
    }
    public string GetPicture()
    {
      return _picture;
    }
    //Setter
    public void SetCity(string city)
    {
      _city = city;
    }
    public void SetDescription(string description)
    {
      _description = description;
    }
    public void SetStayLength(string stayLength)
    {
      _stayLength = stayLength;
    }
    public void SetPicture(string picture)
    {
      _picture = picture;
    }
    //Static
    public static List<Place> GetAll()
    {
      return _placeList;
    }
    public static void DestroyAll()
    {
      _placeList = new List<Place>() {};
    }
    public static Place GetPlaceById(int id)
    {
       return _placeList[id];
    }
  }


}
