

class Pagination {

    card;
    constructor() {
        this.card = {

            Thme: "",
            UserMessage: "",
            DOP: "",
            NickName: ""
        }
    }
    GetPage(pages) {
        
        $.ajax({
            type: "GET",
            url: "/Home/GetAJAX/",
            data: { page: pages },
            success: function (model) {
               
                let any = "";
                this.card = JSON.parse(model)
                $.each(this.card, (index, card) => {


                    any += GetMessage(card);

                })
                any += ` <div class="pag-contener"><span id="left" class="setting">◄</span><span id="right" class="setting">►</span></div>`
                $(".messageContanier").html(any);
            },
            error: function (errorData) { onError(errorData); }
        });
    }



    LoginPage() {


        fetch("/Loggin/Loggin", {
            method: 'Get',
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
function GetMessage(card) {
    return `<div  class="flexContainerMessage ">
                <div class="mainMessage ">
                    <div class="theme boxShadow">
                        <h2>Тема</h2><span>${card.Thme}</span>
                    </div>
                    <div class="containerInfo">
                        <div class="userInfo">
                            <p>Автор:</p>
                            <p>${card.NickName}</p>
                            <p>Дата публикации:</p>
                            <p>${card.DOP}</p>
                        </div>
                        <div class="message">
                        ${card.UserMessage}
                        </div>
                    </div>
                </div>
                </div>
                `
};







export default { Pagination }