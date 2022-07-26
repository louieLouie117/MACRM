
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
        document.getElementById("DidCxAnswer").innerText = " ";



    }

    if(e.target.id === "Action3"){
        document.getElementById("ConfirmAddress").style.display = "none";
        document.getElementById("ActionOptions1").style.display = "flex";
        document.getElementById("ActionOptions2").style.display = "none";
        document.getElementById("DidCxAnswer").innerText = "Did the customer answer?";
    }

    if(e.target.id === "Action4"){
        document.getElementById("ActionOptions1").style.display = "none";
        document.getElementById("ActionOptions2").style.display = "none";
        document.getElementById("ActionOptions3").style.display = "flex";

        document.getElementById("ModelSerialNumber").style.display = "grid";
    }

    if(e.target.id === "Action5"){
        document.getElementById("ActionOptions1").style.display = "none";
        document.getElementById("ActionOptions2").style.display = "flex";
        document.getElementById("ActionOptions3").style.display = "none";

        document.getElementById("ModelSerialNumber").style.display = "none";
    }

    if(e.target.id === "Action6"){
        document.getElementById("ActionOptions1").style.display = "none";
        document.getElementById("ActionOptions2").style.display = "none";
        document.getElementById("ActionOptions3").style.display = "none";
        document.getElementById("ActionOptions4").style.display = "flex";

        document.getElementById("ProvingQuestions").style.display = "grid";
    }

    
    if(e.target.id === "Action7"){
        document.getElementById("ActionOptions1").style.display = "none";
        document.getElementById("ActionOptions2").style.display = "none";
        document.getElementById("ActionOptions3").style.display = "flex";
        document.getElementById("ActionOptions4").style.display = "none";

        document.getElementById("ProvingQuestions").style.display = "none";
    }


       
    if(e.target.id === "Action8"){
        document.getElementById("ActionOptions1").style.display = "none";
        document.getElementById("ActionOptions2").style.display = "none";
        document.getElementById("ActionOptions3").style.display = "non";
        document.getElementById("ActionOptions4").style.display = "none";
        document.getElementById("ActionOptions5").style.display = "flex";


        document.getElementById("AppointmentOutcome").style.display = "grid";
    }
       
    
    
};

const MapHandler =(e)=>{
    document.getElementById("JobMainInfo").style.display = "none";
    document.getElementById("JobCommitsContainer").style.display = "none";
    document.getElementById("mapMain").style.display = "grid";
    

}