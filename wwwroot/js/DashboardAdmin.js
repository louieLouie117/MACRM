 const FakeDataGeneratorHandler =(e) =>{
     console.log("button was click")
   
     document.getElementById("apiServiceJobNumber").value = "SNWQ" + Math.floor(1000000 + Math.random() * 9000) + "-1";
     document.getElementById("apiSamsungJobNumber").value = "416" + Math.floor(10000 + Math.random() * 9000);

   
     var warrantyOptions = ['COD', 'Warranty'];
     var Warranty = warrantyOptions[Math.floor(Math.random()*warrantyOptions.length)];
     document.getElementById("apiInWarranty").value = Warranty;

     
     var stateOptions = ['Kansas', 'Missouri'];
     var Warranty = stateOptions[Math.floor(Math.random()*stateOptions.length)];
     document.getElementById("apiState").value = Warranty;
   

     $.getJSON(`https://random-data-api.com/api/address/random_address`, data => {
        console.log(data, "data is here")
        document.getElementById("apiAddress").value = data.street_address;
        document.getElementById("apiCity").value = data.city;
        document.getElementById("apiZipecode").value = data.zip;
    })

    
    $.getJSON(`https://random-data-api.com/api/users/random_user`, data => {
        console.log(data, "User data is here")
       document.getElementById("apiName").value = data.first_name + " " + data.last_name;
        document.getElementById("apiPhoneNumber").value = data.phone_number;
        document.getElementById("apiEmail").value = data.email;
    })

    var ProductOptions = ['Washer', 'Refrigerator', 'Ice Maker', 'Sealed System'];
     var Window = ProductOptions[Math.floor(Math.random()*ProductOptions.length)];
     document.getElementById("apiProductLine").value = Window;

     var WindowOptions = ['AM', 'PM'];
     var Window = WindowOptions[Math.floor(Math.random()*WindowOptions.length)];
     document.getElementById("apiAppointmentWindow").value = Window;


     var MarketOptions = ['Kansas City', 'Kansas City-OEM'];
     var Market = MarketOptions[Math.floor(Math.random()*MarketOptions.length)];
     document.getElementById("apiMarket").value = Market;

    if(Market === "Kansas City"){
     document.getElementById("apiMarketCode").value = "BF445";

    }

    if(Market === "Kansas City-OEM"){
        document.getElementById("apiMarketCode").value = "BF798";
   
       }
     
    };


   

