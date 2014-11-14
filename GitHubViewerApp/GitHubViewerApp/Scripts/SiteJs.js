

    function showLoginPopup(reponame, username) {
        $("#username").val(username);
        $("#reponame").val(reponame);
        $("#result").dialog("open");
        //  window.location = "GitHome/collaborators/?username=" + username + "&reponame=" + reponame + "";
        return false;
    }
$("#result").dialog({
    autoOpen: false,
    title: 'Login',
    width: 500,
    height: 'auto',
    modal: true
});

function ValidateForm() {
    if ($("#authoName").val() == "") {
        alert("please Enter UserName");
        return false;
    }
    if ($("#authoPassword").val() == "") {
        alert("please Enter Password");
        return false;
    }

}
