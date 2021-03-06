@{
    ViewBag.Title = "Index";
}

<h2>S�r�kle birak file upload</h2>
<div id="dropArea">
    Dosyay� buraya b�rak�n.
    @*BURASI SURUKLEYIP BIRAKACAGIMIZ ALAN*@
</div>
<h4> Y�klenen dosyalar :</h4>
<ul class="list-group" id="uploadList">
  @*dragOver olay� tamamlananen dosyalar� listeleyecek*@
</ul>

<style>
    #dropArea {
        background-color:aliceblue;
        border: black dashed 1px;
        height: 40px;
        text-align: center;
        color: #000000;
        line-height:40px;
    }

    .active-drop {
        background: #ea9898 !important;
        border: solid 2px blue !important;
        opacity: .5;
        color: black !important;
    }
</style>

@section Scripts{

    <script src="~/Scripts/jquery.filedrop.js"></script>
    <script>
        $(function () {
            $("#dropArea").filedrop({
                url: '@Url.Action("UploadFiles")',
                allowedfiletypes: ['image/jpeg', 'image/png', 'image/gif'],
                allowedfileextensions: ['.jpg', '.jpeg', '.png', '.gif'],
                paramname: 'files',
                maxfiles: 5, //MAX 5 RESIM
                maxfilesize: 5, //MB
                dragOver: function () {
                    $('#dropArea').addClass('active-drop');
                },
                dragLeave: function () {
                    $('#dropArea').removeClass('active-drop');
                },
                drop: function () {
                    $('#dropArea').removeClass('active-drop');
                },
                afterAll: function (e) {
                    $('#dropArea').html('Dosya(lar) y�klendi.');
                },
                uploadFinished: function (i, file, response, time) {
                    $("#uploadList").append('<li class="list-group-item">' + file.name+  '</li>');
                }
            })
        })
    </script>
}