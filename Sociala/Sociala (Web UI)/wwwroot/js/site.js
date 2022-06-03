// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var message;

var obj = {};




function Layotloadtime(message) {

    //alert(`${message}`);
}



var response = "";

function Get() {



    try {
        var userUrl = `Home/GetPost`;

        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {

            try {
                if (this.readyState == 4) {


                    response = JSON.stringify(JSON.parse(this.responseText));



                    JSON.parse(this.responseText).forEach(function (r) {

                         console.log(r.postMessage + ' ' + r.postDate + ' ' + r.userIdForPost + ' ' + r.PostImage);



                        //document.getElementById("getAllPost").innerHTML = context;
                    });


                    console.log(JSON.stringify(this.responseText)[2].PostMessage);

                }
            }
            catch (erMs) {

                alert(erMs);

            }
        };

        xhttp.open("GET", userUrl, true);
        xhttp.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        xhttp.send();

    }
    catch (erMsg) {

        alert(erMs);

    }



}

var checkaddpost = false;

function AddPost(timer) {

    var dataform = $("#Postform").serialize();
    obj = new Object();

    console.log(document.getElementById('Userid').value);



    var inputObj = {

        PostMessage: document.getElementById('Posttext').value,
        PostImage: document.getElementById('Photofileupload').value.substring('C:\fakepath\\'.length).substring('\\'.length),
        PostVideo: document.getElementById('Videofileupload').value.substring('C:\fakepath\\'.length).substring('\\'.length),
        PostDate: document.getElementById('Dateid').value,
        UserId_forPost: document.getElementById('Userid').value

    }



    var p = JSON.stringify(inputObj);

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(request.responseText);
        }
    };

    request.open("POST", `Home/AddPost`, true);
    request.setRequestHeader("Content-type", "application/json; charset=UTF-8");


    request.send(p);


    document.getElementById('Photofileupload').value = null;
    document.getElementById('Videofileupload').value = null;

    checkaddpost = true;
    console.log(p);


    //setInterval(() => {

    //    if (checkaddpost == true) {

    //        window.open(window.location.reload(true), "_self");
    //    }

    //}, 10000);






}


var size = 0;

function uploadFiles(inputId, videobool) {

    if (videobool == false) {

        var input = document.getElementById("Photofileupload");
    }
    else {
        var input = document.getElementById("Videofileupload");
    }
    var files = input.files;
    var formData = new FormData();


    for (var i = 0; i != files.length; i++) {

        size = files[i].size;

        if (files[i].size < 5555) {

            alert(`Maximum allowed file size is ${555555555 * 1 / 1048576} mb. Minimum allowed file size is ${5555 * 1 / 1048576} mb`);

            document.getElementById('Photofileupload').value = null;
            document.getElementById('Videofileupload').value = null;

        }

        if (files[i].size > 555555555) {

            alert(`Maximum allowed file size is ${555555555 * 1 / 1048576} mb. Minimum allowed file size is ${5555 * 1 / 1048576} mb`);

            document.getElementById('Photofileupload').value = null;
            document.getElementById('Videofileupload').value = null;
        }

        else {

            formData.append("files", files.item(i));
        }

    }

    setInterval(() => {

        if (checkaddpost == true) {

            if (size > 5555) {

                $.ajax(
                    {
                        url: `Home/UploadFiles`,
                        data: formData,
                        processData: false,
                        contentType: false,
                        type: "POST",
                        success: function (data) {
                            
                            alert("Files Uploaded!");


                

                        },
                        error: function (xhr, textStatus, errorThrown) {
                            alert(errorThrown);
                        }
                    }
                );



                checkaddpost = false;
            }
        }

    }, 1000);



}




function AddTag() {

    var dataform = $("#Postform").serialize();
    obj = new Object();

    console.log(document.getElementById('Userid').value);



    var array = []
    var checkboxes = document.querySelectorAll('input[type=checkbox]:checked')




    for (var i = 0; i < checkboxes.length; i++) {

        array.push(checkboxes[i].value)

    }

    var inputObj = {


        TagTitle1: array[0],
        TagTitle2: array[1],
        TagTitle3: array[2],
        TagTitle4: array[3],
        TagTitle5: array[4],
        TagTitle6: array[5],
        TagTitle7: array[6],
        TagTitle8: array[7],
        TagTitle9: array[8],
        TagTitle10: array[9],
        TagTitle11: array[10],
        TagTitle12: array[11],
    }



    var p = JSON.stringify(inputObj);

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(request.responseText);
        }
    };

    request.open("POST", `Home/AddTag`, true);
    request.setRequestHeader("Content-type", "application/json; charset=UTF-8");


    request.send(p);



    checkaddpost = true;
/*    alert(p);*/

}

function Add(timer, idpost, idtag) {
    AddPost(timer);
    AddTag();

    setInterval(() => {

        if (idpost >= 0 || idtag >= 0) {

            AddPostandTag(idpost, idtag);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 5000);
        }
        else {

            AddPostandTag(idpost, idtag);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 5000);
        }
    }, 5000);

}


function GetTag() {


    try {
        var userUrl = `Home/GetTag`;

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {

            try {
                if (this.readyState == 4) {


                    response = JSON.stringify(JSON.parse(this.responseText));



                    JSON.parse(this.responseText).forEach(function (r) {

                        console.log(r.tagTitle1 + ' ' + r.tagTitle2 + ' ' + r.tagTitle3 + ' ' + r.tagTitle4);


                        //document.getElementById("getAllPost").innerHTML = context;
                    });


                    console.log(JSON.stringify(this.responseText)[2].PostMessage);

                }
            }
            catch (erMs) {

                alert(erMs);

            }
        };

        xhttp.open("GET", userUrl, true);
        xhttp.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        xhttp.send();

    }
    catch (erMsg) {

        alert(erMs);

    }
}




function AddPostandTag(idpost, idtag) {

    obj = new Object();


 

    var inputObj = {

        PostId_forPostandTag: idpost,
        TagId_forPostandTag: idtag

    }



    var p = JSON.stringify(inputObj);

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(request.responseText);
        }
    };

    request.open("POST", `Home/AddPostandTag`, true);
    request.setRequestHeader("Content-type", "application/json; charset=UTF-8");


    request.send(p);




    console.log(p);



}

var countclick=0;

function fillandcommentactive(index) {

  

    if (document.getElementById(`${index} fillarea`).style.visibility === "visible") {

        document.getElementById(`${index} fillarea`).style.visibility = "hidden";
        document.getElementById(`${index} commentarea`).style.visibility = "hidden";
        document.getElementById(`${index} commenttextarea`).style.display = "none";


    }
    else {

        document.getElementById(`${index} fillarea`).style.visibility = "visible";
        document.getElementById(`${index} commentarea`).style.visibility = "visible";
        document.getElementById(`${index} commenttextarea`).style.display = "block";

    }
}


function getcurrentpostid() {

    return document.getElementById("ReactionPostId").value;
}


function AddReaction_1(idpost, idUser) {


    obj = new Object();

    var count = 0;


    alert(document.getElementById("Reaction1").value);


    var inputObj = {

        Reaction_1: parseInt(document.getElementById("Reaction1").value),
        Reaction_2: parseInt(document.getElementById("Reaction2").value),
        Reaction_3: parseInt(document.getElementById("Reaction3").value),
        Reaction_4: parseInt(document.getElementById("Reaction4").value),
        Reaction_5: parseInt(document.getElementById("Reaction5").value),
        Reaction_6: parseInt(document.getElementById("Reaction6").value),
        Reaction_7: parseInt(document.getElementById("Reaction7").value),
        Reaction_8: parseInt(document.getElementById("Reaction8").value),

        PostId_forReaction: idpost,
        UserId_forReaction: idUser

    }



    //var p = JSON.stringify(inputObj);

    //var request = new XMLHttpRequest();
    //request.onreadystatechange = function () {
    //    if (this.readyState == 4 && this.status == 200) {
    //        console.log(request.responseText);
    //    }
    //    else {
    //        console.log(request.error);
    //    }
    //};

    //request.open("POST", `Home/AddReaction`, true);
    //request.setRequestHeader("Content-type", "application/json; charset=UTF-8");


    //request.send(p);

    obj.Reaction_1 = parseInt(document.getElementById("Reaction1").value);
    obj.Reaction_2 = parseInt(document.getElementById("Reaction2").value);
    obj.Reaction_3 = parseInt(document.getElementById("Reaction3").value);
    obj.Reaction_4 = parseInt(document.getElementById("Reaction4").value);
    obj.Reaction_5 = parseInt(document.getElementById("Reaction5").value);
    obj.Reaction_6 = parseInt(document.getElementById("Reaction6").value);
    obj.Reaction_7 = parseInt(document.getElementById("Reaction7").value);
    obj.Reaction_8 = parseInt(document.getElementById("Reaction8").value);
    obj.PostId_forReaction = idpost;
    obj.UserId_forReaction = idUser;

    var dataform = $("#form2_1").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


    //$.ajax({
    //    type: "POST", //REQUEST TYPE
    //    dataType: "json", //RESPONSE TYPE
    //    contentType: "application/json; charset=utf-8",
    //    data: JSON.stringify(obj),
    //    url: "Home/AddReaction",
    //    success: function (data) {
    //        console.log("Lidl Adicionado!");
    //    },
    //    error: function (err) {
    //        console.log("AJAX error in request: " + JSON.stringify(err, null, 2));
    //    }
    //}).always(function (jqXHR, textStatus) {
    //    if (textStatus != "success") {
    //        alert("Error: " + jqXHR.statusText);
    //    }
    //});


}


function AddReaction_2(idpost, idUser) {



    var dataform = $("#form2_2").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


}


function AddReaction_3(idpost, idUser) {



    var dataform = $("#form2_3").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


}


function AddReaction_4(idpost, idUser) {



    var dataform = $("#form2_4").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


}


function AddReaction_5(idpost, idUser) {



    var dataform = $("#form2_5").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


}


function AddReaction_6(idpost, idUser) {



    var dataform = $("#form2_6").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


}


function AddReaction_7(idpost, idUser) {



    var dataform = $("#form2_7").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log.log('Failed ');
        }
    })


}


function AddReaction_8(idpost, idUser) {



    var dataform = $("#form2_8").serialize();

    console.log(dataform);

    $.ajax({
        type: 'POST',
        url: '/Home/AddReaction',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: dataform,
        success: function (result) {
            console.log('Successfully received Reaction Data ');
            console.log(result);

            setTimeout(() => {

                window.open(window.location.reload(true), "_self");
            }, 1000);
        },
        error: function () {
            alert('Failed to receive Reaction the Data');
            console.log('Failed ');
        }
    })


}



function AddComment(PostId_forComment, UserId_forComment, index) {


    const d = new Date();

    if (document.getElementById(`${index} CommentMessage`).value.length == 0) {
        alert("empty")
    }

    var inputObj = {

        CommentMessage: document.getElementById(`${index} CommentMessage`).value,
        CommentDate: d.toString(),
        PostIdForComment: PostId_forComment,
        UserIdForComment: UserId_forComment
 
    }


    var dataform = $("#form3").serialize();

    console.log(dataform);

    //$.ajax({
    //    type: 'POST',
    //    url: '/Home/AddComment',
    //    contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
    //    data: dataform,
    //    success: function (result) {
    //        console.log('Successfully received Reaction Data ');
    //        console.log(result);

    //        setTimeout(() => {

    //            window.open(window.location.reload(true), "_self");
    //        }, 1000);
    //    },
    //    error: function () {
    //        alert('Failed to receive Reaction the Data');
    //        console.log('Failed ');
    //    }
    //})



    $.ajax({
        type: "POST",  // http method
        url: "/Home/AddComment",
        data: JSON.stringify(inputObj),  // data to submit
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        timeout: 2500,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Content-length", 0);

        },
        success: function (data, status, xhr) {
            console.log("AddComment status: " + status + ", AddComment data: " + data);

                setTimeout(() => {

                    window.open(window.location.reload(true).substring('#').length, "_self");
            }, 2500);

        },
        error: function (jqXhr, textStatus, errorMessage) {
            console.log("AddComment Error " + errorMessage);


        }
    });





    //var p = JSON.stringify(inputObj);

    //var request = new XMLHttpRequest();
    //request.onreadystatechange = function () {
    //    if (this.readyState == 4 && this.status == 200) {
    //        console.log(request.responseText);
    //    }
    //};

    //request.open("POST", `Home/AddComment`, true);
    //request.setRequestHeader("Content-type", "application/json; charset=UTF-8");








}



//function Updatecurrentuserdate(Id) {




//    var today = new Date();

//    var url = "/Home/Updatecurrentuserdate";

//    obj = new Object();
//    obj.Id = Id;
//    obj.UserOnlineDate = today.toString();


//        setTimeout(function () {


//            $.ajax({
//                type: 'PUT',  // http method
//                url: 'Home/Updatecurrentuserdate',
//                data: JSON.stringify(obj),  // data to submit
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",

//                success: function (data, status, xhr) {
//                    console.log("AddComment status: " + status + ", AddComment data: " + data);



//                },
//                error: function (jqXhr, textStatus, errorMessage) {
//                    console.log(textStatus + "" + "AddComment Error " + errorMessage);

//                }
//            });

//        }, 2000);
//}


window.onload = function main() {

    var autoClick;

    setTimeout(() => {
        if (autoClick == true) {
            window.click()
        }
    }, 0);

}

var addFriendname;


function GetUsers(e) {

    let item = "";

    setInterval(() => {

   
 

        $.ajax({
            url: "/Home/GetAllActiveUsers",
            method: "GET",
            success: function (data) {
                let content = "";

          
                for (var i = 0; i < data.length; i++) {
                    let style = '';


                    if (data[i].isOnline == true) {
                        style = 'border:5px solid green;';
                    }
                    else {
                        style = 'border:5px solid red;';
                    }

                    currentusername = data[0].userName;

                    addFriendname = data[i].userName;


           



                        item = `             
                           <div style=${style} class="card-body d-flex pt-4 ps-4 pe-4 pb-0 border-top-xs bor-0">
                             <figure class="avatar me-3"><img  src="Images/UserProfileImage/${data[i].profilePicture}"
                                        alt="image" class="shadow-sm rounded-circle w45"></figure>
                                <h4 class="fw-700 text-grey-900 font-xssss mt-1">${data[i].userName} <span
                                        class="d-block font-xssss fw-500 mt-1 lh-3 text-grey-500">12 mutual
                                        friends</span></h4>
                            </div>
                                <div  onclick="FindCurrentUser('${data[i].id}');" class="card-body d-flex align-items-center pt-0 ps-4 pe-4 pb-4" >
                                  <form name="${data[i].id}_friendform" id="friendform" class="form-text" method="post" asp-controller="Home" asp-action="AddFriend" role="form" enctype="multipart/form-data">
                                    <a style="cursor:pointer" id="addFri" onclick="AddFriend('${data[i].userName}');"
                                       class="p-2 lh-20 w100 bg-primary-gradiant me-2 text-white text-center font-xssss fw-600 ls-1 rounded-xl">Send
                                    </a>
                                    <a href="#"
                                    class="p-2 lh-20 w100 bg-grey text-grey-800 text-center font-xssss fw-600 ls-1 rounded-xl">Delete</a>
                                 </form>
                               </div>
                         
                           `
                    

                    content += item;
                }


                document.getElementById("activeUsers").innerHTML = content;
                console.log(data);
            },
            error: function (err) {
                console.log(err);
            }
        });
        $.ajax({
            url: "/Home/GetAllUsers",
            method: "GET",
            success: function (data) {
                let content = "";
                let item = "";



                for (var i = 0; i < data.length; i++) {
                    let statustext = '';
                    let statuscolor = '';
                    if (data[i].isOnline) {
                        statustext = 'Online';
                        statuscolor = 'success';


                    }
                    else {
                        statustext = 'Offline';
                        statuscolor = 'danger';


                    }


              

                    item = `<li id="${data[i].id}_activeusers" onclick="chatboxopen('${data[i].id}_activeusers');  FindCurrentUser('${data[i].id}');"
                        class="bg-transparent list-group-item no-icon pe-0 ps-0 pt-2 pb-2 border-0 d-flex align-items-center">
                        <figure class="avatar float-left mb-0 me-2">
                            <img src="Images/UserProfileImage/${data[i].profilePicture}" alt="image" class="w35">
                        </figure>
                        <h3 class="fw-700 mb-0 mt-0">
                            <a class="font-xssss text-grey-600 d-block text-dark model-popup-chat" href="#">${data[i].userName}</a>
                        </h3>
                        <span id="statusspan" class="badge badge-${statuscolor} text-white badge-pill fw-500 mt-0"> ${statustext}</span>
                    </li>`

                    content += item;
                }

                document.getElementById("allUsers").innerHTML = content;
                console.log(data);
            },
            error: function (err) {
                console.log(err);
            }
        });


    }, 1000);


}

function chatboxopen(id) {

    alert(id)


    document.getElementById("chatbox").style.display = "block";


}

function sendmessage() {

    alert("Hello");
}



var curuseridimage;
var currentusername = "";
var selectedusername = "";
var selectedid = "";

function FindCurrentUser(id) {

 
        let style = "";
        let status = "";


        $.ajax({
            url: `/FindCurrentUser/${id}`,
            method: "GET",
            success: function (data) {

                if (data.isOnline == true) {
                    style = 'success';
                    status = "Online";
                }
                else {
                    style = 'danger';
                    status = "Offline";
                }


                curuseridimage = data.profilePicture;
                selectedusername = data.userName;
                selectedid = data.id;

                //document.getElementById("receivertext").value = null;
                //document.getElementById("sendertext").value = null;

                console.log(data.userName);

                document.getElementById("ReceiverUserName").innerHTML = data.userName;
                document.getElementById("ReceiverUserImage").src = "Images/UserProfileImage/" + data.profilePicture;

                //var content = `<span id="statusspanchat" class="d-inline-block bg-${style} btn-round-xss m-0"></span> ${status}`;

                //document.getElementById("ReceiverOnlinestatus").innerHTML = content;

        
             
            },
            error: function (err) {
                console.log(err);
            }
        });
   
}


var senderfriend;
var receiverfriend;

function AddMessage(sender, receiver) {


    senderfriend = sender;
    receiverfriend = receiver;

    obj = new Object();



    const today = new Date();

    var inputObj = {

        MessageDate: today.toString(),
        MessageText: document.getElementById("chattextarea").value,
        SenderUserId: sender,
        ReceiverUserId: receiver

    }


    $.ajax({
        type: 'POST',  // http method
        url: 'Home/AddMessage',
        data: inputObj,  // data to submit
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",

        success: function (data) {
            console.log("Added successfully");



            var content = "";
            var commoncontent = "";

            alert("Addddd: "+document.getElementById("chattextarea").value);



            content += ` <br/> <div class="message-content font-xssss lh-24 fw-500">${document.getElementById('chattextarea').value}</div>`;

            document.getElementById("receivertext").innerHTML += content;


            setInterval(() => {

                document.getElementById('chattextarea').innerHTML = null;
                content = null;
                document.getElementById("receivertext").innerHTML = null;

                window.open(window.location.reload(true), "_self");

                //$("#chatbox").load("Home/AddMessage");
 
            }, 1000);




        },
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr, textStatus, errorThrown.message);
        }
    });









    //setInterval(() => {

    //    if (checkaddpost == true) {

    //        window.open(window.location.reload(true), "_self");
    //    }

    //}, 10000);






}


$(document).ready(function () {
    $('#ReceiverUserName').trigger('click');
});


function GetMessage(img, IdUser) {


    let style = "";
    let status = "";



    setInterval(() => {

        try {

            var userUrl = `Home/GetMessage`;

            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {

                try {
                    if (this.readyState == 4) {


                        response = JSON.stringify(JSON.parse(this.responseText));


                        var content1 = "";
                            var content2 = "";

                        JSON.parse(this.responseText).forEach(function (r) {


                            //console.log(r.messageText + ' ');
                            //console.log(r.senderUserId + ' ');

                            console.log(IdUser + ' IdUser');




             


                            console.log(r.messageText + ' sender:' + r.senderUserId + ' receiver:' + r.receiverUserId);

                            console.log(r.messageText + ' ');

                            if (r.senderUserId == IdUser) {
                                content1 += `
                               <img src="/images/UserProfileImage/${img}" class="shadow-sm rounded-circle w25 h25 z-depth-5" data-holder-rendered="true">
                                <div class="message-content font-xssss lh-24 fw-500"> <pre-wrap> ${r.messageText} </pre-wrap> </div> <br/><br/>`;

                            }
                            if (r.receiverUserId == IdUser) {

                                content1 += `
                               <img src="/images/UserProfileImage/${curuseridimage}" class="shadow-sm rounded-circle w25 h25 z-depth-5" data-holder-rendered="true">
                                <div class="message-content font-xssss lh-24 fw-500"> <pre-wrap> ${r.messageText} </pre-wrap></div> <br/><br/>`;
                            }
                          



                        });


                        document.getElementById("sendertext").innerHTML = content1;



                    }
                }
                catch (erMs) {

                    alert(erMs);

                }
            };

            xhttp.open("GET", userUrl, true);
            xhttp.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
            xhttp.send();

        }
        catch (erMsg) {

            alert(erMs);

        }


    }, 1000);


}


var addfriend = false;

var addedfriend

function AddFriend(id) {


    alert(id + " "+selectedid);

    obj = new Object();



   
        var inputObj = {

            FriendName: id.userName,
            UserId_forFriend: selectedid,

        }


        $.ajax({
            type: 'POST',  // http method
            url: 'Home/AddFriend',
            data: JSON.stringify(inputObj),  // data to submit
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (data, status, xhr) {

          


                window.open(window.location.reload(true), "_self");

            },
            error: function (jqXhr, textStatus, errorMessage) {
                console.log(textStatus + "" + "AddFriend Error " + errorMessage);

            }
        });




    





    //setInterval(() => {

    //    if (checkaddpost == true) {

    //        window.open(window.location.reload(true), "_self");
    //    }

    //}, 10000);






}



//function GetFriend() {

//    setInterval(() => {



//        $.ajax({
//            url: "/Home/GetFriend",
//            method: "GET",
//            success: function (data) {
//                let content = "";

//                let item = "";
//                for (var i = 0; i < data.length; i++) {
//                    let style = '';
//                };
//            }
//        });

//    }, 1000)
//}