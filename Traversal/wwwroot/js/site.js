function confirmDelete(uniqueId, isDeleteClicked) {
    if (isDeleteClicked) {
        $('#' + 'deleteSpan_' + uniqueId).hide();
        $('#' + 'confirmDeleteSpan_' + uniqueId).show();
    }
    else {
        $('#' + 'deleteSpan_' + uniqueId).show();
        $('#' + 'confirmDeleteSpan_' + uniqueId).hide();
    }
}