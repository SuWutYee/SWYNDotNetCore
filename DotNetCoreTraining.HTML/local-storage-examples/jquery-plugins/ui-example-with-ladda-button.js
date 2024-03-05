let tblBlog = "Tbl_Blog";
let _blogId = '';
runBlog();

function runBlog() {
  readBlog();
  // for (let i = 0; i < 100; i++) {
  //   createBlog("title" + (i + 1), "author" + (i + 1), "content" + (i + 1))
  // }
}

function readBlog() {
  $("#tbBlog").html("");
  let lstBlog = getBlogs();
  let htmlBlog = "";
  for (let i = 0; i < lstBlog.length; i++) {
    let item = lstBlog[i];
    htmlBlog += `
                  <tr>
                    <th scope="row">${i + 1}</th>
                    <td>${item.Title}</td>
                    <td>${item.Author}</td>
                    <td>${item.Content}</td>
                    <td>
                      <button type="button" class="btn btn-warning" onclick="editBlog('${item.Id}')">Edit</button>
                      <button type = "button" class="btn btn-danger" onclick="deleteBlog('${item.Id}')"> Delete</button>
                    </td>
                  </tr >
      `;
  }
  console.log(htmlBlog);
  $("#tbBlog").html(htmlBlog);
}

function createBlog(title, author, content) {
  let lstBlog = getBlogs();

  let blog = {
    Id: uuidv4(),
    Title: title,
    Author: author,
    Content: content,
  };

  lstBlog.push(blog);

  setLocalStorage(lstBlog);

  readBlog();
}

function editBlog(id) {
  let lstBlog = getBlogs();
  let lstResult = lstBlog.filter((x) => x.Id == id); // return array
  if (lstResult.length == 0) {
    console.log("No data found.");
    return;
  }
  let item = lstResult[0];
  console.log(item);
  $("#title").val(item.Title);
  $("#author").val(item.Author);
  $("#content").val(item.Content);
  _blogId = item.Id;
}

function updateBlog(id, title, author, content) {
  let lstBlog = getBlogs();

  let lstItem = lstBlog.filter((x) => x.Id == id);
  if (lstItem.length == 0) {
    console.log("No data found.");
    return;
  }

  let index = lstBlog.findIndex((x) => x.Id == id);
  lstBlog[index] = {
    Id: id,
    Title: title,
    Author: author,
    Content: content,
  };

  setLocalStorage(lstBlog);
}

function deleteBlog(id) {

  Notiflix.Confirm.show(
    'Confirm',
    'Are you sure you want to delete?',
    'Yes',
    'No',
    function okCb() {
      Notiflix.Block.arrows('#frmMain');
      setTimeout(() => {
        let lstBlog = getBlogs();
        let lstItem = lstBlog.filter((x) => x.Id == id); // return array
        if (lstItem.length == 0) {
          console.log("No data found.");
          return;
        }
        let lstResult = lstBlog.filter((x) => x.Id != id);
        setLocalStorage(lstResult);
        Notiflix.Block.remove('#frmMain');
        ShowSuccessMessage("Delete Successful.");
        readBlog();
      }, 3000);
    },
    function cancelCb() {
    }
  );
}

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}

function getBlogs() {
  let lstBlog = [];
  let blogStr = localStorage.getItem(tblBlog);
  if (blogStr != null) {
    lstBlog = JSON.parse(blogStr);
  }
  return lstBlog;
}

function setLocalStorage(blogs) {
  let jsonStr = JSON.stringify(blogs);
  localStorage.setItem(tblBlog, jsonStr);
}

$("#btnSave").click(function (e) {
  e.preventDefault();

  var l = Ladda.create(this);
  l.start();

  const title = $("#title").val();
  const author = $("#author").val();
  const content = $("#content").val();

  if (_blogId === '') {
    setTimeout(() => {
      createBlog(title, author, content);
      l.stop();
      ShowSuccessMessage("Saving Successful.");
      
      $("#title").val("");
      $("#author").val("");
      $("#content").val("");
      $("#title").focus();
      readBlog();
    }, 3000);
  }
  else {
    updateBlog(_blogId, title, author, content);
    l.stop();
    ShowSuccessMessage("Edit Successful.");
    $("#title").val("");
    $("#author").val("");
    $("#content").val("");
    $("#title").focus();
    readBlog();
    _blogId = '';
  }
});

function ShowSuccessMessage(message) {
  // Notiflix.Notify.success(message);
  Notiflix.Report.success('Success', message, 'Ok');
}
