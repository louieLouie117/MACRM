
console.log("dashboardSA.js for SA is running ")

const PreScreenActionsHandler = (e)=>{
    e.preventDefault();
    console.log(e.target.id);
    if(e.target.id === "Action1"){
        console.log("Submit as pre-screen unsuccessful");
        document.getElementById("JobStatusPSF").value = "Unsuccessful Pre-Screen";
        document.getElementById("JobStatusColorPSF").value = "8E6C88";
        document.getElementById("SpecialInstructionsPSF").value = "Unsuccessful Pre-Screen";
        NewJobHandler(e);
        return



    }
    if(e.target.id === "Action2"){
        document.getElementById("ConfirmAddress").style.display = "grid";
        document.getElementById("ActionOptions1").style.display = "none";
        document.getElementById("ActionOptions2").style.display = "flex";



    }

    if(e.target.id === "Action3"){
        document.getElementById("ConfirmAddress").style.display = "none";
        document.getElementById("ActionOptions1").style.display = "flex";
        document.getElementById("ActionOptions2").style.display = "none";

    }
       
    
    
};

const MapHandler =(e)=>{
    document.getElementById("JobMainInfo").style.display = "none";
    document.getElementById("JobCommitsContainer").style.display = "none";
    document.getElementById("mapMain").style.display = "grid";
    

}