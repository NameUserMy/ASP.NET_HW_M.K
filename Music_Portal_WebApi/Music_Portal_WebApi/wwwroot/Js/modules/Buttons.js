
import page from "./Pages.js"
const pages = new page.Pages();
class Button {


    #menuUser;
    #musicMenu
    constructor(){
        this.#menuUser = ["/html/UserForm.html", "/html/EditUserForm.html"];
        this.#musicMenu = ["/html/AddGenre.html", "/html/AddPerf.html", "/html/AddTrack.html"];
    }

    UserMenu(buttonIndex) {
        if (buttonIndex > 0) {
            pages.GetStaticPage(this.#menuUser[buttonIndex-1]);
        } else { 
            pages.UserPage("api/User");
        }
    }

    MusicMenu(buttonIndex) {

        console.log('-->>' + buttonIndex);
        pages.GetStaticPage(this.#musicMenu[buttonIndex]);
        switch (buttonIndex) {

            case 1:
                pages.GetGenreData("/api/Genre");
                break;
            case 2:
                pages.GetGenreData("/api/Genre");
                pages.GetPerformerData("/api/Performers");
                break;
            case 3:
                pages.EditGenrePage("/api/Genre");
                break;
            case 4:
                pages.EditGenrePage("/api/Track");
                break;
            case 5:
                pages.EditPerformerPage("/api/Performers");
                break;
           

        }
    }





}

export default { Button }