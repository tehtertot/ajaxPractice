$(document).ready(function() {
    getNotes();
})

function getNotes() {
    $.get('/notes', function(res) {
        for (var n in res) {
            displayNote(n);
        }
    })
}

function displayNote(n) {
    $('#notes').prepend(`<div> 
                            <h2>${n.Title}</h2>
                            <form>
                                <input type="hidden" value="${n.NoteId}">
                                <textarea>${n.Description}</textarea>
                                <input type="submit" value="Update">
                            </form>
                         </div>`)
}