

class RequestApi { 


    UserPost(urlUser) {

        let form = new FormData(document.getElementById('userRegistration'));
      
        const headers = {
            "Content-Type": "application/json;charset=UTF-8"
        }
        fetch(urlUser, {
            method: 'POST',
            body: JSON.stringify(Object.fromEntries(form)),
            headers: headers,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

            document.getElementById('userRegistration').reset();

        });

    }

    UserPut(urlUser) {

        let form = new FormData(document.getElementById('userEdit'));

        const headers = {
            "Content-Type": "application/json;charset=UTF-8"
        }
        fetch(urlUser, {
            method: 'PUT',
            body: JSON.stringify(form),
            headers: headers,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

            document.getElementById('userEdit').reset();

        });
    }

    UpdateConfirm(urlUser) {

        const headers = {
            "Content-Type": "application/json"
        }
        fetch(urlUser, {
            method: 'PUT',
            headers: headers,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

        });

    }

    DeleteUser(urlUser) {
        const headers = {
            "Content-Type": "application/json"
        }
        fetch(urlUser, {
            method: 'Delete',
            headers: headers,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

        });



    }


    AddTrack(urlTrack) {

        console.log("hhhhhh");
        //document.getElementById('trackUpload')
        //const file = $(`#file-upload`);
        const [file] = $(`#file-upload`).prop('files');
        const form = new FormData()
        form.append('uploadFile', file);
        form.append('IdGenre', $(`#genreSelect`).val());
        form.append('IdPerformer', $(`#performerSelect`).val());

        const headers = {
            'Accept': 'application/json',
           
        }
        fetch(urlTrack, {
            method: 'POST',
            headers: headers,
            encType: 'multipart/form-data',
            body: form,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

            document.getElementById('trackUpload').reset();

        });


    }

    AddGenre(url) {


        let form = new FormData(document.getElementById('AddGenreForm'));
        const headers = {
            "Content-Type": "application/json;charset=UTF-8"
        }
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(Object.fromEntries(form)),
            headers: headers,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

            document.getElementById('AddGenreForm').reset();

        });



    }


    AddPerformer(url) {


        let form = new FormData();

        form.append("Name", $(`#Name`).val());
        form.append("GenreId", $(`#genreSelect`).val());
        const headers = {
            "Content-Type": "application/json;charset=UTF-8"
        }
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(Object.fromEntries(form)),
            headers: headers,

        }).then(response => {

            if (response.ok) {

                console.log(response.status)

            } else {
                return response.json().then(error => {

                    const e = new error("Ex...");
                    e.data = error;

                });

            }

            document.getElementById('formPerformer').reset();

        });



    }




}

export default { RequestApi }