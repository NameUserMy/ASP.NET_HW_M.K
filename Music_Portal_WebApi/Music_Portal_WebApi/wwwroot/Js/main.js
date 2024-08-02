import req from "./modules/Request.js"
import btn from "./modules/Buttons.js" 

const request = new req.RequestApi();
const buttons = new btn.Button();



$(document).ready(() => {



    $(`#userMenu`).on('mousedown', (e) => {
        buttons.UserMenu($(e.target).index());
    })
    $(`#musicMenu`).on(`mousedown`, (e) => {
        buttons.MusicMenu($(e.target).index());
    })
 
    $(`#RenderBody`).on(`mousedown`, ".confirm-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.UpdateConfirm(`/api/User/${id}`);
        buttons.UserMenu(0);
    });

    $(`#RenderBody`).on(`mousedown`, ".delete-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.DeleteUser(`/api/User/${id}`);
        buttons.UserMenu(0);
    });

    //performer
    $(`#RenderBody`).on(`mousedown`, ".performer-delete-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.DeletePerformer(`/api/Performers/${id}`);
        buttons.MusicMenu(5);
    });

    $(`#RenderBody`).on(`mousedown`, ".performe-confirm-button", (e) => {

        let index = $(e.target).parent(`.GTP-form`).index();
        let parent = $(`.GTP-form`);
        request.UpdatePerformer(`/api/Performers`, $(e.target).attr(`data-info`), $(parent[index]).find("input").val());
        buttons.MusicMenu(5);
    });
    /** */

    //track
    $(`#RenderBody`).on(`mousedown`, ".track-delete-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.DeleteTrack(`/api/Track/${id}`);
        buttons.MusicMenu(4);
    });
    $(`#RenderBody`).on(`mousedown`, ".track-confirm-button", (e) => {
        let index = $(e.target).parent(`.GTP-form`).index();
        let parent = $(`.GTP-form`);
        request.UpdateTrack(`/api/Track`, $(e.target).attr(`data-info`), $(parent[index]).find("input").val());
        buttons.MusicMenu(4);
    });
    //*** */

    //genre
    $(`#RenderBody`).on(`mousedown`, ".genre-delete-button", (e) => {
        let id = $(e.target).attr(`data-info`);
        request.DeleteGenre(`/api/Genre/${id}`);
        buttons.MusicMenu(3);
    });
    $(`#RenderBody`).on(`mousedown`, ".genre-confirm-button", (e) => {
        let index = $(e.target).parent(`.GTP-form`).index();
        let parent = $(`.GTP-form`);
        request.UpdateGenre(`/api/Genre`, $(e.target).attr(`data-info`), $(parent[index]).find("input").val());
        buttons.MusicMenu(3);
    });
    //*** */


    //form button
    $(`#RenderBody`).on(`mousedown`, "#userReg-Btn", () => {
        request.UserPost("/api/User/");
    });

    $(`#RenderBody`).on(`mousedown`, "#userEdit-Btn", () => {
        request.UserPut("/api/User/");
    });

    $(`#RenderBody`).on(`mousedown`, `#addTrack`, (e) => {
        e.preventDefault();
        request.AddTrack("/api/Track");
    });

    $(`#RenderBody`).on(`mousedown`, `#addGenre`, (e) => {
        e.preventDefault();
        request.AddGenre("/api/Genre");
    });


    $(`#RenderBody`).on(`mousedown`, `#addPerformer`, (e) => {
        e.preventDefault();
        request.AddPerformer("/api/Performers");
    });



});