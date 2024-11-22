
$(document).ready(function () {
   
    $(document).on("keyup", "#search-box", function () {
        console.log("Keyup triggered!"); 
        doSearch();
    });
  
    function doSearch() {
        var url = $("#frmSearchBooks").data("url"); 
    
        $.get(url, $("#frmSearchBooks").serialize(), function (BooksList) {
            $("#dvList").html(BooksList); 
        }).fail(function (err) {
            console.error("AJAX failed:", err); 
        });
    }
});
function fillPageId(id) {
    console.log(id);
    $('#pageId').val(id);
    $('#filter-search').submit();
}

