
console.log("dashboardSA.js for SA is running ")

const InWarrantyHandler = (e)=>{
    console.log("In warranty handler was click", e.target.innerText)
        if(e.target.innerText == "Yes"){
            document.getElementById("InWarrantyYes").style.background = "#6900D1";
            document.getElementById("InWarrantyYes").style.color = "white";

            document.getElementById("InWarrantyNo").style.background = "White";
            document.getElementById("InWarrantyNo").style.color = "black";
            return

        }
        if(e.target.innerText == "No"){
            document.getElementById("InWarrantyYes").style.background = "white";
            document.getElementById("InWarrantyYes").style.color = "black";

            document.getElementById("InWarrantyNo").style.background = "#6900D1";
            document.getElementById("InWarrantyNo").style.color = "white";
            return
        }
    
    
};