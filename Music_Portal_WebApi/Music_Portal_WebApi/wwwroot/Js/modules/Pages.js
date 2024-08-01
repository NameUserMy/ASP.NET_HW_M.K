
class Pages {


    #userConfirm;
    #userUnConfirm;
    #user;
    #userPage;
    #staticPage;

    #genreSelect;
    #performerSelect;
    constructor() {
        this.#performerSelect = {

            id: "",
            name: "",

        }
        this.#genreSelect = {

            id: "",
            title:""

        };
        this.#userConfirm = "";
        this.#userUnConfirm = "";
        this.#userPage = "";
        this.#staticPage = "";
        this.#user = {

            id:"",
            nickName: "",
            confirmation: "",

        };
    }

     async UserPage(url){
        
        
       const headers = {
            "Content-Type": "application/json"
        }

       let temp = await fetch(url, {

            method: "Get",
            headers: headers
            

        })

         this.#user = await temp.json();
         console.log(this.#user);
         $("#RenderBody").html(this.#UserPageResponse());
        
    }
     async GetStaticPage(url) {
        this.#staticPage = null;
        const headers = {
            "Content-Type":"text/html"
        }

       this.#staticPage = await fetch(url, {
            method: "Get",
            headers: headers
        })
       $("#RenderBody").html(await this.#staticPage.text());

    }
     async GetGenreData(url) {
      
        const headers = {
            "Content-Type": "application/json"
        }

        let temp = await fetch(url, {

            method: "Get",
            headers: headers


        })

        this.#genreSelect = await temp.json();
        $("#genreSelect").html(this.#GenreResponseList());

    }
     async GetPerformerData(url) {

        const headers = {
            "Content-Type": "application/json"
        }

        let temp = await fetch(url, {

            method: "Get",
            headers: headers


        })

         this.#performerSelect = await temp.json();
         console.log()
        $("#performerSelect").html(this.#performerResponseList());

    }
    async EditGenrePage(url) {
        const headers = {
            "Content-Type": "application/json"
        }
       
       let temp = await fetch(url, {

            method: "Get",
            headers: headers


        })

        this.#genreSelect = await temp.json();
         console.log(this.#genreSelect);
         $("#RenderBody").html(this.#GenrePageResponse());


    }
    async EditPerformerPage(url) {
        const headers = {
            "Content-Type": "application/json"
        }

        let temp = await fetch(url, {

            method: "Get",
            headers: headers


        })

        this.#performerSelect = await temp.json();
        console.log(this.#performerSelect);
        $("#RenderBody").html(this.#performerPageResponse());


    }
    #GenreResponseList() {
        let select = "";
        select = `
        <option value = "" selected = "selected"> Choise genre </option>
                 `;
        for (let key in this.#genreSelect) {

            select += `
                <option value="${this.#genreSelect[key].id}">${this.#genreSelect[key].title}</option>
            `
              
        }
        
        return select;
    }
    #performerResponseList() {
        let select = "";
        select = `
        <option value="" selected="selected">Choise performer</option>
                 `;
        for (let key in this.#performerSelect) {

            select += `
                <option value="${this.#performerSelect[key].id}">${this.#performerSelect[key].name}</option>
            `

        }

        return select;
    }
    #UserPageResponse() {


        this.#userConfirm = "";
        this.#userUnConfirm=""
        
        for (let key in this.#user) {

            if (this.#user[key].
                confirmation == false) {

                this.#userUnConfirm += `
                     <div class="users-confirm-form ">
                        <span class="nick-name">${this.#user[key].nickName}</span>
                        <span class="confirm-button" data-info="${this.#user[key].id}">Сonfirm</span>
                        <span class="delete-button"  data-info="${this.#user[key].id}">Delete</span>
                     </div>
                   `

            } else {
                this.#userConfirm += `
                     <div class="users-confirm-form ">
                        <span class="nick-name">${this.#user[key].nickName}</span>
                        <span class="confirm-button" data-info="${this.#user[key].id}">Block</span>
                        <span class="delete-button" data-info="${this.#user[key].id}">Delete</span>
                     </div>
                            
                            
                   `
            }
        }
       
        this.#userPage = `
               <div id="user-confirm-contener">
                 <div class="itemConfirm">
                       ${this.#userConfirm}
                    </div>
                    <div class=" itemUnconfirm">
                        ${this.#userUnConfirm}
                    </div>
                </div>
            `

      
        return this.#userPage;


    }
    #GenrePageResponse() {

        let genre = "";
        let genreItem = "";

        for (let key in this.#genreSelect) {

            genreItem += `
             <div class="GTP-form">
                <input class="nick-name custom-input" value="${this.#genreSelect[key].title}">
                    <span class="confirm-button" data-info="${this.#genreSelect[key].id}">Comfirm</span>
                    <span class="delete-button" data-info="${this.#genreSelect[key].id}">Delete</span>
              </div>
            
            `
        }
        genre = `<div id = "genre-contener">
                    ${genreItem}
                </div>
        ` 

        return genre;
    }
    #performerPageResponse() {

        let performer = "";
        let performerItem = "";

        for (let key in this.#performerSelect) {

            performerItem += `
             <div class="GTP-form">
                <input class="nick-name custom-input" value="${this.#performerSelect[key].name}">
                    <span class="confirm-button performerConfirm" data-info="${this.#performerSelect[key].id}">Comfirm</span>
                    <span class="delete-button performerDelete" data-info="${this.#performerSelect[key].id}">Delete</span>
              </div>
            
            `
        }
        performer = `<div id = "genre-contener">
                    ${performerItem}
                </div>
        `

        return performer;
    }
}
export default{ Pages }