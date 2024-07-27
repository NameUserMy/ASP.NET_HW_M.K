



class PostMethod{

   
    constructor() {
        
    }
    PublishMessage() {
        let  inData = new FormData();
        inData.append("Message", $("#Message").val());
        inData.append("Theme", $("#Theme").val());
       
        $.ajax({
            url: "/Message/MessageSend",
            type: "POST",
            data: inData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('error: ' + textStatus);
            }
        });
           
     
        document.getElementById("messagSend").reset();
    }
    Registration() {

        let form = new FormData(document.getElementById("userRegistration"));
       fetch("/Registration/UserRegistration",{
            method: 'POST',
            body: form,
           
        }).then(response => {

            if (response.ok) {
               
                
            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }
          
            document.getElementById("userRegistration").reset();

        });
    }
}




export default{ PostMethod }