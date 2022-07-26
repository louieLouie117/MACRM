
console.log("app.js files is running and working")
let AddressEntered ="";
let geocoder;
let map;
let DefaultAddress = "1101 Church St Nashville TN 37201";
// const AddressList = [
//   {address : "1101 Church St Nashville TN 37201"},
//   {address : "4881 Teakwood Dr Oakley Ca 94561"},
//   {address : "2900 Baby Ruth Ln TN 37013"}
// ]
// console.log("AddressList", AddressList);
// const AddressLoop =(data)=>{
//     for (let index = 0; index < data.length; index++) {
//       const element = data[index].address;
      
//       console.log(element)
      
//     }
// }










console.log("outside function", AddressEntered)
// Multiple Markers----------------------
let locations = [
  // ['loan 1', 36.04540532617211, -86.63816821722166, 'address 1'],
];
const addressList = [
  {address: "2900 Baby Ruth Ln Antioch TN 37013"},
  {address: "3002 windgate ave 37211"},
]

function getLocation() {
  if (navigator.geolocation) {
     navigator.geolocation.getCurrentPosition(showPosition);
  } else {
    console.log("Geolocation is not supported by this browser.");
        }
  };
function showPosition(position) {
  console.log("Latitude: " + position.coords.latitude,"Longitude: " + position.coords.longitude);   
  locations.push(['GeoLocation',position.coords.latitude,position.coords.longitude, 'Starting Point'])
};
getLocation();  

// 
function initialize() {
  let myOptions = {
    center: new google.maps.LatLng(36.04540532617211, -86.63816821722166),
    zoom: 10,
    mapTypeId: google.maps.MapTypeId.ROADMAP
  };
  let map = new google.maps.Map(document.getElementById("map"),
      myOptions);

  // Covert text formatted address into lat and long
  const ConvertAddress = (data) =>{
      console.log("Convert Address data", data);
      let count = 0;
      for (let index = 0; index < data.length; index++) {
            const element = data[index].address;
            // console.log("address to convert:", element);
            geocoder = new google.maps.Geocoder();
            // console.log("geocoder", geocoder);
            geocoder.geocode({'address':element}, function(results, status) {
                console.log(" converted address results", results)
                if (status === 'OK') {
                  count++
                  // console.log(element,"|| Coordinates || ", "lat:", results[0].geometry.bounds.vb.hi, "Long:", results[0].geometry.bounds.Ra.hi,)
                  let latCoordinate =  results[0].geometry.bounds.vb.hi;
                  let longCoordinate = results[0].geometry.bounds.Ra.hi;
                  locations.push([element,latCoordinate, longCoordinate, 'Customers Info'])
                  // need to call in the loop
                  setMarkers(map,locations)
              } else {
                  alert('Geocode was not successful for the following reason: ' + status);
              }
            }); 
        };        
  };
  ConvertAddress(addressList);
}


function setMarkers(map,locations){
    console.log("Set Markers location", locations)
    for (let i = 0; i < locations.length; i++){  
        let loan = locations[i][0]
        let lat = locations[i][1]
        let long = locations[i][2]
        let add =  locations[i][3]
        latlngset = new google.maps.LatLng(lat, long);
        let marker = new google.maps.Marker({  
                map: map, title: loan , position: latlngset  
              });
              map.setCenter(marker.getPosition())

          let content = "Loan Number: " + loan +  '</h3>' + "Address: " + add     
          let infowindow = new google.maps.InfoWindow()
          google.maps.event.addListener(marker,'click', (function(marker,content,infowindow){ 
          return function() {
            infowindow.setContent(content);
            infowindow.open(map,marker);
          };
      })(marker,content,infowindow)); 
    }}

  // 





    
// Search box results----------------------------------
const SearchAddressHandler =(e)=>{
  e.preventDefault();
AddressEntered = document.getElementById("SearchAddress").value;
console.log("inside function", AddressEntered)
  let map = new google.maps.Map(document.getElementById('map'), {
    zoom: 8,
    center: {lat: -34.397, lng: 150.644}
  });
  geocoder = new google.maps.Geocoder();
  codeAddress(geocoder, map);
console.log("Search button was click")
function codeAddress(geocoder, map,) {
  
  geocoder.geocode({'address':AddressEntered}, function(results, status) {
    console.log("Search Results", results)
    console.log("Here is lat", results[0].geometry.bounds.vb.hi)
    console.log("Here is long", results[0].geometry.bounds.Ra.hi)
    console.log("lat: 36.04538027656666, log: -86.6387390442064");
    locations.push(['Added address',results[0].geometry.bounds.vb.hi, results[0].geometry.bounds.Ra.hi, 'pushed'])
    if (status === 'OK') {
      map.setCenter(results[0].geometry.location);
      console.log("results geometry",results[0].geometry)
      let marker = new google.maps.Marker({
        map: map,
        position: results[0].geometry.location
      });
      
    } else {
      alert('Geocode was not successful for the following reason: ' + status);
    }
  });
}
return AddressEntered;
}



// Render map and Geolocation address----------------------------------------
function initMap() {
  if(document.getElementById("SearchAddress").value === ""){
    console.log("input empty")
  
// Get user geoLocation
      function getLocation() {
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(showPosition);
        } else {
            console.log("Geolocation is not supported by this browser.");
        }
      }
      function showPosition(position) {
        console.log("Latitude: " + position.coords.latitude,"Longitude: " + position.coords.longitude);   
       let myLatLng = {lat: position.coords.latitude, lng: position.coords.longitude}
        let map = new google.maps.Map(document.getElementById('map'), {
          zoom: 11,
          center: myLatLng
        });
        console.log("map",map)
        new google.maps.Marker({
          position: myLatLng,
          map,
          title: "Hello World!",
        });
      }
      getLocation();
   
    geocoder = new google.maps.Geocoder();
    codeAddress(geocoder, map);
    console.log("Search button was click")
    function codeAddress(geocoder, map,) {
      geocoder.geocode({'address':DefaultAddress}, function(results, status) {
        console.log("Here is the results", results)
        if (status === 'OK') {
          // map.setCenter(results[0].geometry.location);d
          console.log("geometry results",results[0].geometry)
          let marker = new google.maps.Marker({
            map: map,
            position: results[0].geometry.location
          });
        } else {
          alert('Geocode was not successful for the following reason: ' + status);
        }
      });
    }  
    return
  }
 
}

