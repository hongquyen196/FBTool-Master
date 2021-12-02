//Get Fb_dtsg
javascript: (() => {
    if (window.location.host !== "m.facebook.com") {
        window.open("https://m.facebook.com");
        return;
    }
    var fb_dtsg = document.querySelector('[name="fb_dtsg"]').value;
    if (fb_dtsg) {
        window.prompt("fb_dtsg", fb_dtsg);
    }
})();

javascript: (() => {
    if (window.location.host !== "m.facebook.com") {
        window.open("https://m.facebook.com");
    }
    //Create __input_Attachment
    document.getElementById("viewport").remove();
    var input = document.createElement("input");
    input.type = "file";
    input.id = "__input_Attachment";
    document.body.appendChild(input);

    //Send request
    var fb_dtsg = document.querySelector('[name="fb_dtsg"]').value;
    var formData = new FormData();
    formData.append("source", 8);
    formData.append("farr", input.files[0]);
    var url = "https://upload.facebook.com/ajax/react_composer/attachments/photo/upload?__a=1&fb_dtsg=" + fb_dtsg;

    var request = new XMLHttpRequest();
    request.open("POST", url, true);
    request.onload = function(e) {
        console.log(request.responseText);
    };
    request.send(formData);


    $.ajax({
        url: url,
        data: formData,
        processData: false,
        contentType: false,
        type: 'POST',
        success: function(data) {
            console.log(data);
        }
    });



})();

//Get Page ID
javascript: (function() {
    const page_name = document.title;
    const found = (check) => {
        if (check && check[0]) {
            window.prompt(`PAGE ID của ${page_name}:`, check[0]);
            return true;
        }
        return false;
    };
    if (found(/(?<=\"pageID\"\:\")(.*?)(?=\")/.exec(document.body.innerHTML)))
        return;
    if (found(/(?<=facebook\.com\/)(.*?)($|(?=\/)|(?=&))/.exec(location.href)))
        return;
    window.prompt(
        "Không tìm thấy PAGE ID nào trong url!\nBạn có đang ở đúng trang page fb chưa?\nTrang web Ví dụ:",
        "https://www.facebook.com/ColourfulSpace"
    );
})();