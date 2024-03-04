let tblBlog = "Tbl_Blog";
runBlog();

function runBlog() {
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
  let lstBlog = getBlogs();
  for (let i = 0; i < lstBlog.length; i++) {
    let item = lstBlog[i];
    console.log(
      "Id >>> " +
      item.Id +
      "Title >>> " +
      item.Title +
      " Author >>> " +
      item.Author +
      " Content >>> " +
      item.Content
    );
  }
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
}

function editBlog(id) {
  let lstBlog = getBlogs();
  let lstResult = lstBlog.filter((x) => x.Id == id); // return array
  if (lstResult.length == 0) {
    console.log("No data found.");
    return;
  }
  let item = lstResult[0];
  console.log(
    "Id >>> " +
    item.Id +
    "Title >>> " +
    item.Title +
    " Author >>> " +
    item.Author +
    " Content >>> " +
    item.Content
  );
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
  let lstBlog = getBlogs();

  let lstItem = lstBlog.filter((x) => x.Id == id); // return array
  if (lstItem.length == 0) {
    console.log("No data found.");
    return;
  }

  let lstResult = lstBlog.filter((x) => x.Id != id);
  setLocalStorage(lstResult);
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
