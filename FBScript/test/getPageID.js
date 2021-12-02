// Get Page ID
//
// Work on URL: 
//     - https://www.facebook.com/sinhvienHueIT
//     - https://m.facebook.com/sinhvienHueIT
var page_id = /(?<=pageID.*:")(.*?)(?=\")/gm.exec(document.body.innerHTML)[0];
console.log(page_id);