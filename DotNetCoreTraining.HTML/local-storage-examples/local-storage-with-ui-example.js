let tblBlog = "Tbl_Blog";
let _blogId = '';
runBlog();

function runBlog() {
  readBlog();
  //   createBlog("title1", "author1", "content1");
  //   readBlog();
  //   editBlog("a2578f3a-f4da-48ce-9e65-f00c820012bf");
  //   editBlog("2");
  //   let id = prompt("Enter Id");
  //   deleteBlog(id);
  //   let id = prompt("Enter Id");
  //   let title = prompt("Enter Title");
  //   let author = prompt("Enter Author");
  //   let content = prompt("Enter Content");
  //   updateBlog(id, title, author, content);
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
  let result = confirm("Are you sure want to delete?");
  if (!result) return;

  let lstBlog = getBlogs();

  let lstItem = lstBlog.filter((x) => x.Id == id); // return array
  if (lstItem.length == 0) {
    console.log("No data found.");
    return;
  }

  let lstResult = lstBlog.filter((x) => x.Id != id);
  setLocalStorage(lstResult);
  readBlog();
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

$("#btnSave").click(function () {
  const title = $("#title").val();
  const author = $("#author").val();
  const content = $("#content").val();

  if (_blogId === '') {
    createBlog(title, author, content);
    alert("Saving Successful.");
  }
  else {
    updateBlog(_blogId, title, author, content);
    alert("Edit Successful.");
    _blogId = '';
  }

  $("#title").val("");
  $("#author").val("");
  $("#content").val("");

  $("#title").focus();

  readBlog();
});
