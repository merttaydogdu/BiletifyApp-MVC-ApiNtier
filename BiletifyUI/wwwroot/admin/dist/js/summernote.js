$(document).ready(function () {
    $('#Properties').summernote({
        callbacks: {
            onChange: function (contents, $editable) {
                var cleanContents = stripHtml(contents);
                $('#Properties').summernote('code', cleanContents);
            }
        }
    });
});
function stripHtml(html) {
    var tmp = document.createElement("DIV");
    tmp.innerHTML = html;
    return tmp.textContent || tmp.innerText || "";
}
