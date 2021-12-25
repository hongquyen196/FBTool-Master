//GET YOUR POST_ID FROM /reviews
var regex = /(?<=story_fbid=)(\d+)/g.exec(document.body.innerHTML)
if (regex && regex[0]) {
    return regex[0];
}
return 0;