//////////////////////////////////////////////////////////////////////
/**
*** BASE URL
**/
//////////////////////////////////////////////////////////////////////
function baseURL(){
	var url = $('#baseURL').val()
	return url
}
//////////////////////////////////////////////////////////////////////
/**
*** The main function
**/
//////////////////////////////////////////////////////////////////////
function initialize(){
	
	
	///////////////////////////////////////////////////////////////
	/************** Show and hide comments, show post form  ******/
	$(document).on('click', '#commentsCount' ,function(){
		$this = $(this)
		var postID = $(this).data("id2")
		var parent = $(this).closest('.post')
		$('#comment-Wrapper', parent).toggle(1000)
		//countComment(postID, $this)
		getPostComment(postID, $this)
	})
	
	
	
	$('#createPostBtn').on('click', function(){
		$(this).hide(1000)
		$('#userPostForm').show(1000)
	})
	
	
	//////////////////////////////////////////////////////////////
	/************ Auto load page when you close edit modal *****/
	$(document).on('click', '#closeModalBtn', function(){
		location.reload();
	})
}

////////////////////////////////////////////////////////////////////////////////
/**
*** this function get user information from database into
*** the modal when the page is loaded
*** this function also refresh the modal after each updates
**/
///////////////////////////////////////////////////////////////////////////////
function getUpdates(){
	$.post("profile/getupdatedprofile",{id:$('.modal-content').data("id")}, function(data,status){
		//alert(status);
		$('#getUpdate').html(data);
	});
}

/////////////////////////////////////////////////////////////////////
/**
*** This function gets user timeline from databse
**/
//////////////////////////////////////////////////////////////////////
function getUserTimeline(){
	$.post('profile/getuserTimeline', {userID:$('.modal-content').data("id")}, function(data,status){
		$('#timeline').html(data)
	})
}


/////////////////////////////////////////////////////////////////////
/**
*** Onlick button function that update users biography and Interests
**/
//////////////////////////////////////////////////////////////////////
$(document).on('click','#btnBioUpdate', function(){
	var id = $('.modal-content').data("id");
	var title = $('#title option:selected').text();
	var city = $('#city').text();
	var country = $('#country').text();
	var phone = $('#phone').text();
	var bio = $('#bio').text();
	var interest = $('#interest').text();
	$.post("profile/updatebio", {id:id,title:title,city:city,country:country,phone:phone,bio:bio,interest:interest}, function(data, status){
		if(data == 'added'){
			$('#modalStatus').css('color', 'green');
			$('#modalStatus').html('<strong>Updated Successfully</strong>')
			var n = 3;
			var i = setInterval(function(){  
				if(n == 0){
					getUpdates();
					clearInterval(i);
				}
				n--;
			}, 400);
		}else{
			$('#modalStatus').css('color', 'red');
			$('#modalStatus').html('<strong>Error Updating</strong>')
		}
		//getUpdates();
	})
})

/////////////////////////////////////////////////////////////////////
/**
*** Onlick button function that update user's social media links
**/
/////////////////////////////////////////////////////////////////////

$(document).on('click','#btnSocialUpdate', function(){
	var id = $('.modal-content').data("id");
	var facebook = $('#facebook').text();
	var googleplus = $('#googleP').text();
	var linkedIn = $('#linkedIn').text();
	var twitter = $('#twitter').text();
	var website = $('#website').text();
	
	$.post("profile/updatesocial", {id:id,facebook:facebook,googleplus:googleplus,linkedIn:linkedIn,twitter:twitter,website:website}, function(data, status){
		if(data == 'added'){
			$('#modalStatus').css('color', 'green');
			$('#modalStatus').html('<strong>Updated Successfully</strong>')
		}else{
			$('#modalStatus').css('color', 'red');
			$('#modalStatus').html('<strong>Error Updating</strong>')
		}
		getUpdates();
	})
})

/////////////////////////////////////////////////////////////////////
/**
*** postData is a function to post values to the server(PHP)
**/
/////////////////////////////////////////////////////////////////////
function postData(url, value){
	var result = $.post(url,value)
	return result;
}


/////////////////////////////////////////////////////////////////////
/**
*** Onlick button function that updates user's Password
**/
/////////////////////////////////////////////////////////////////////
$(document).on('click','#btnSecurityUpdate', function(){
	var id = $('.modal-content').data("id");
	var oldPassword = $('#oldPassword').val();
	var newPassword = $('#newPassword').val();
	var passwordToMatch = $('#matchPassword').val();
	var pageType = $('#pwdFrom').val();
	var url = '';
	if(pageType == 'user'){
		url = "profile/updatesecurity";
	}else{
		url = "index/updatesecurity";
	}
	
	var value = {id:id,oldPassword:oldPassword,newPassword:newPassword};
	if(validatePassword(newPassword)&&matchPassword(newPassword,passwordToMatch)&& oldPassword !== ''){
		postData(url, value).done(function(data){
			alert(data)
			//getUpdates();
		})
	}else{
		alert("Error")
	}
})

/////////////////////////////////////////////////////////////////////
/**
*** Password Validation function
**/
/////////////////////////////////////////////////////////////////////
function validatePassword(passwordInput){
	//var newPassword = $('#newPassword').val();
	var checkstrength = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
	if(passwordInput == ''){
		alert("Password must not be empty");
	}else if(passwordInput.length < 7){
		alert("Password must be greater than 7 characters");
		return false;	
	}else if(!passwordInput.match(checkstrength)){
		alert("password must contain at least one uppercase, lowercase and number");
		return false;
	}else{
		return true;
	}	
}
function matchPassword(passwordInput, matchpasswordInput) {
	/*var newPassword = $('#newPassword').val();
	var passwordToMatch = $('#matchPassword').val();*/
	if(matchpasswordInput.match(passwordInput)){
		return true;
	}else{
		alert("Password don't match");
		return false;
	}
}

/////////////////////////////////////////////////////////////////////
/**
*** Function to delete User account
**/
/////////////////////////////////////////////////////////////////////
$(document).on('click','#disableAccount', function(){
	if(confirm("Are you sure you want to disable your account? ")){
		$.post("profile/disable",{id:$('.modal-content').data("id")}, function(data,status){
			if(data == 'done'){
				window.location = "http://localhost/infocomm/logout/logout";
			}
		});
	}
})

/////////////////////////////////////////////////////////////////////
/**
*** This function post user data to update when the text fields 
*** looses focus
**/
/////////////////////////////////////////////////////////////////////

function addEducation(id, userID, value, column){
	$.post('profile/addEdu',{id:id, userID:userID, value:value, column:column}, function(data, success){
	})
}

/////////////////////////////////////////////////////////////////////
/**
*** Add publication function
**/
/////////////////////////////////////////////////////////////////////

$(document).on('click', '#pubSubmitBtn', function(){
	var pubTitle = $('#pubTitle').val();
	var userID = $('#pubAuthor').data("id");
	var pubType = $('#pubType option:selected').text();
	var category = $('#pubCategory option:selected').val();
	var publink = $('#pubLink').val();
	
	var value = {userID:userID,pubTitle:pubTitle,pubType:pubType,category:category,publink:publink};
	var url = "publications/addpub";
	if($('#t_c').is(':checked')){
		if((pubTitle&&pubType&&category&&publink) != ''){
			postData(url, value).done(function(data){
				alert(data);
				$("form").trigger("reset");
				window.location = $('#baseURL').val()+'user/profile';
			})
		}else{
			alert("Fields must not be empty");
		}
	}else{
		alert('Terms and conditions must be checked');
	}
})

/////////////////////////////////////////////////////////////////////
/**
*** Update Publication function 
**/
/////////////////////////////////////////////////////////////////////
$(document).on('click', '#pubUpdateBtn', function(){
	var pubTitle = $('#pubTitle').val();
	var pubID = $('#pubID').val();
	var pubType = $('#pubType option:selected').text();
	var category = $('#pubCategory option:selected').val();
	var publink = $('#pubLink').val();
	
	var value = {pubID:pubID,pubTitle:pubTitle,pubType:pubType,category:category,publink:publink};
	var url = "publications/update";
	if($('#t_c').is(':checked')){
		if((pubTitle&&pubType&&category&&publink) != ''){
			postData(url, value).done(function(data){
				alert(data);
				window.location = $('#baseURL').val()+'user/profile';
				//$("form").trigger("reset");
			})
		}else{
			alert("Fields must not be empty");
		}
	}else{
		alert('Terms and conditions must be checked');
	}
})

//////////////////////////////////////////////////////////////////////
/**
*** Function 1: Send data to the server processing
*** Function 2: Check if a user is already following another user
*** Function 3: Follow a user 
*** Function 4: Unfollow a user
*** Function 5: Count the number of followers by a user
**/
//////////////////////////////////////////////////////////////////////
function isFollowed(url, isLoggedIn, follower, value){
	if(follower !== ''){
		postData(url, value).done(function(data){
			if(data == 'You already following user' || data == 'done'){
				$('#followBTNspan').html('<button id="followingBtn" class="btn btn-danger btn-block"><b>Unfollow</b></button>')
			}
		})
	}	
}

function checkUserFollower(){
	//Check if user is already following anither user
	var isLoggedIn = $('#isLoggedIn').val()
	var follower = $('#follower').val();
	var url = 'profile/checkFollow';
	var value = {id:isLoggedIn, follower:follower};
	
	countFollowers(isLoggedIn, follower)
	
	if(isLoggedIn != 0 && follower !== ''){
		isFollowed(url, isLoggedIn, follower, value);
	}
}

//$('#followUserBtn').on('click', function(){
$(document).on('click','#followUserBtn', function(){
	var isLoggedIn = $('#isLoggedIn').val()
	var follower = $('#follower').val();
	var url = 'profile/follow';
	var value = {id:isLoggedIn, follower:follower};
	
	if(isLoggedIn == 0){
		alert("You must be logged in to follow this user")
	}else{
		isFollowed(url, isLoggedIn, follower, value);
		
		var n = 3;
		var i = setInterval(function(){  
			if(n == 0){
				countFollowers(isLoggedIn, follower);
				clearInterval(i);
			}
			n--;
		}, 400);
	}
})

$(document).on('click','#followingBtn', function(){
	var isLoggedIn = $('#isLoggedIn').val()
	var follower = $('#follower').val();
	var url = 'profile/unfollow';
	var value = {id:isLoggedIn, follower:follower};
	
	if(isLoggedIn != 0){
		isFollowed(url, isLoggedIn, follower, value);
		$('#followBTNspan').html('<button id="followUserBtn" class="btn btn-primary btn-block"><b>Follow</b></button>')
	}
	
	var n = 3;
	var i = setInterval(function(){  
		if(n == 0){
			countFollowers(isLoggedIn, follower);
		  	clearInterval(i);
		}
		n--;
	}, 400);	
});

function countFollowers(userID, followerID){
	var newID = "";
	if(followerID == ''){
		newID = userID;
	}else{
		newID = followerID;
	}
	var value = {id:newID};
	var url = 'profile/countFollowers';
	
	postData(url, value).done(function(data){
		var following = data.split('-')[1];
		var followers = data.split('-')[0];
		
		$('#followingList').html('<li class="list-group-item">\
                  <b>Followers</b> <a class="pull-right">'+followers+'</a>\
                </li>\
                <li class="list-group-item">\
                  <b>Following</b> <a class="pull-right">'+following+'</a>\
                </li>')
		$('.headerFollowers').html(followers)
		
	})
}

/////////////////////////////////////////////////////////////////////////
/**
*** Increase the height of input form for comments in profile.php page
*** Reference: https://stackoverflow.com/questions/17772260/textarea-auto-height#
*** Date Accessed: 09/10/2017
*** Obtained from: stackoverflow
**/
/////////////////////////////////////////////////////////////////////////
function autoHeight(element)
{
	element.style.height = "5px";
	element.style.height = (element.scrollHeight + 20) + "px";
}
//////////////////////////////////////////////////////////////////////
/**
*** Report User function, using button on click
**/
//////////////////////////////////////////////////////////////////////
$(document).on('click', '#reportBtn', function(){
	var userID = $('#reportID').val()
	var reason = $('#reason').val()
	var url = 'profile/report';
	var value = {userID:userID, reason:reason};
	postData(url, value).done(function(data){
		if(data == 'reported'){
			$('.reportModalTitle').html("Thank you")
			$('.reportModalBody').html("<p>We have received your complaint concerning this user, we will respond accordingly and swiftly.</p>")
			$('.reportModalFooter').html("")
		}
	});
})


//////////////////////////////////////////////////////////////////////
/**
*** Delete publication function
**/
//////////////////////////////////////////////////////////////////////
$(document).on('click', '#deletePubBtn', function(){
	var id = $(this).data("id10");
	$.post("profile/deletePub",{id:id}, function(data,status){
		alert(data);
	});
})

//////////////////////////////////////////////////////////////////////
/**
*** Send user's post to database
**/
//////////////////////////////////////////////////////////////////////
$('#submitPostBtn').on('click', function(){
	var userID = $('#isLoggedIn').val()
	var description = $('#descriptionPost').val()
	var url = 'profile/postActivity';
	var value = {userID:userID, description:description};
	postData(url, value).done(function(data){
		if(data == 'Posted'){
			$("form").trigger("reset")
			$('#updatePostSpan').show(1000)
			$('#updatePost').html(data)
			getMyPost("")
			$('#updatePostSpan').fadeOut(15000)
		}
	});
})

//////////////////////////////////////////////////////////////////////
/**
*** Send user's project post to database
**/
//////////////////////////////////////////////////////////////////////


function getUserPost()
{
	var pagenumber = $('#pageNumber').val()
	var totalPost = $('#totalPost').val()
	$('.loadingDiv').show()
	var value = {pagenumber:pagenumber,totalPost:totalPost}
	var url = "profile/getAllPost"
	if((pagenumber && totalPost) == "")
	{
		postData(url, value).done(function(data){
			if(data.split('??')[0] == "")
			{
				$('.loadingDiv').hide()
			}
			$('.loadingDiv').hide()
			$('#showComments').html(data.split('??')[0])
			$('.showHiddenInput').html(data.split('??')[1]);
			var n = 3;
			var i = setInterval(function(){  
				if(n == 0){
					checkLike()
					clearInterval(i);
				}
				n--;
			}, 400);
		})
	}
	else if (pagenumber != totalPost)
	{
		postData(url, value).done(function(data){
			if(data.split('??')[0] == "")
			{
				$('.loadingDiv').hide()
			}
			$('.loadingDiv').hide()
			$('#showComments').append(data.split('??')[0])
			$('.showHiddenInput').html(data.split('??')[1]);
			var n = 3;
			var i = setInterval(function(){  
				if(n == 0){
					checkLike()
					clearInterval(i);
				}
				n--;
			}, 400);
		})
	}
	else{
		
	}
	//
	
		/*if(data.split('??')[0] == "")
		{
			$('.loadingDiv').hide()
		}
		if($('#showComments').html() !== '')
		{
			$('.loadingDiv').hide()
			$('#showComments').append(data.split('??')[0])
			$('.showHiddenInput').html(data.split('??')[1]);
			var n = 3;
			var i = setInterval(function(){  
				if(n == 0){
					checkLike()
					clearInterval(i);
				}
				n--;
			}, 400);
		}
		else
		{
			$('.loadingDiv').hide()
			if(pagenumber == totalPost)
			{
				$('#showComments').html(data.split('??')[0])
				$('.showHiddenInput').html(data.split('??')[1]);
			}
		}*/
}

$(document).on('click', '#btn-box-delete', function(){
	var postID = $(this).data('cid')
	var userID = $('#isLoggedIn').val();
	var url = 'profile/deletePost';
	var value = {userID:userID,postID:postID};
	postData(url, value).done(function(data){
		if(data == 'deleted')
		{
			alert(data)
		}
		else
		{
			alert(data)
		}
		
	});
})



function getMyPost(myPostID){
	var userID = $('#isLoggedIn').val();
	$.post("profile/getAllPost",{userID:userID,myPostID:myPostID}, function(data,status){
		if(myPostID !== "")
		{
			$('#showMyPost').html(data)
		}
		else
		{
			$('#showComments').html(data)
		}
	});
}
function getPostComment(postID, $this)
{
	var url = 'profile/getComments';
	var value = {postID:postID};
	postData(url, value).done(function(data){
		var parent = $this.closest('.post')
		$('#comment-Wrapper', parent).html(data)
		countComment(postID, $this)
	});
}


function countComment(postID, $this)
{
	var parent = $this.closest('.post')
	$.post("profile/countComments",{postID:postID}, function(data,status){
		$('#commentsCount',parent).html('<i class="fa fa-comments-o margin-r-5"></i> Comments ('+data+')')
	});
}


$(document).on('click', '#commentPostBtn', function()
{
	$this = $(this)
	var parent = $this.closest('form')
	var postID = $(this).data("id")
	var userID = $('#isLoggedIn').val()
	var description = $('#userCommentText', parent).val()
	var posterID = $('#commentPostBtn',parent).data("pid2")
	//alert(posterID)
	var url = 'profile/sendComments';
	var value = {postID:postID, userID:userID, posterID:posterID, description:description};
	postData(url, value).done(function(data){
		if(data == 'Commented'){
			$("form").trigger("reset")
			$('#updatePostSpan').show(1000)
			$('#updatePost').html(data)
			getPostComment(postID, $this)
			$('#updatePostSpan').fadeOut(15000)
		}
	});
})

$(document).on('click', '#likeComment', function()
{
	$this = $(this)
	var parent = $this.closest('.post')
	var postID = $('#commentPostBtn',parent).data("id")
	var userID = $('#isLoggedIn').val()
	var posterID = $('.user-block',parent).data("pid")
	var url = 'profile/likeComments';
	var value = {userID:userID,postID:postID, posterID:posterID};
	postData(url, value).done(function(data){
		if(data !== 'error')
		{
			$('#likeComment',parent).html('<i class="fa fa-thumbs-o-up margin-r-5"></i> Liked')
			$('.fa-thumbs-o-up',parent).css('color','#21CC00');
			$('#likeCount',parent).html(' ('+data+')')
			
		}
	});
})

function checkLike(){
	$.each($('.user-block'), function(){
		$this = $(this)
		var parent = $this.closest('.post')
		var postID = $('.user-block',parent).data("id5")
		var userID = $('#isLoggedIn').val()
		
		var url = 'profile/checkMyLikes';
		var value = {userID:userID,postID:postID};
		postData(url, value).done(function(data){
			if(data == "yes")
			{
				$('#likeComment',parent).html('<i class="fa fa-thumbs-o-up margin-r-5"></i> Liked')
				$('.fa-thumbs-o-up',parent).css('color','#21CC00');
			}
		})
	})
}
//////////////////////////////////////////////////////////////////////
/**
*** Function to get notification
**/
//////////////////////////////////////////////////////////////////////
function getNotification()
{
	var userID = $('#isLoggedIn').val()
	var url = 'profile/getNotifications';
	var value = {userID:userID};
	setInterval(function(){
		postData(url, value).done(function(data){
			$('.notification-infocomm').html(data)
			countNotification()
		})
	}, 5000);
	
}
function countNotification()
{
	var count = 0;
	$.each($('.notification-infocomm li'), function(){
		count++
	})
	$('.label-notification').html(count)
	$('.header-notification').html('You have '+count+' notifications')
}

$(document).on('click', '#myNotification', function(){
	var nID = $(this).data("id")
	var userID = $('#isLoggedIn').val()
	var url = 'profile/setIsRead'
	var value = {userID:userID,nID:nID};
	postData(url, value).done(function(data){
		if(data == "set")
		{
			getNotification()
		}
	})
})

//////////////////////////////////////////////////////////////////////
/**
*** Page ready function load other function when the page loaded
*** This function also redirects to either login or registration page
*** when the button is clicked
**/
//////////////////////////////////////////////////////////////////////
$(document).ready(function() {	
	$('#loginLink').on('click', function(){
		window.location.href = baseURL()+"user/login";
	})
	$('#registerLink').on('click', function(){
		window.location.href = baseURL()+"user/register";
	})
	
	$(document).on('click','#addEducationBTN', function(){
	$('#eduTable').append('<tr><td>Institute</td><td id="institue" contenteditable="true"></td></tr>\
				<tr><td>Qualification</td><td id="qualif" contenteditable="true"></td></tr>\
				<tr><td>Start Date</td><td id="startDate" contenteditable="true"></td></tr>\
				<tr><td>Graduation Date</td><td id="endDate" contenteditable="true"></td></tr>\
				<tr><td colspan="2"><button id="deleteEdu" data-id="" style="float:right;" class="btn btn-danger">Delete Education</button></td></tr>');
				addEducation('',$('.modal-content').data("id"), '', '')
	})
	
	$(document).on('click', '#deleteEdu', function(){
		var userID = $('.modal-content').data("id")
		var eduID = $(this).data("id5");
		
		$.post('profile/deleteEducation', {userID:userID,eduID:eduID}, function(data){
			if(data == "deleted")
			{
				getUpdates();
			}
		})
	})
	
	$(document).on('blur','#institue',function(){
		var id = $(this).data("id1");
		var text = $(this).text();
		addEducation(id, $('.modal-content').data("id"), text, 'institute')
		//getUpdates();
	})
	$(document).on('blur','#qualif',function(){
		var id = $(this).data("id2");
		var text = $(this).text();
		addEducation(id, $('.modal-content').data("id"), text, 'qualification')
		
	})
	
	////// Load main functions ///////////////////////////////////////
	initialize();
	
});
$('#changeImgBtn').on('click', function(){
	$('#changeImgInput').trigger('click');
})
$(document).on('change', '#imgUpld', function(e){
	e.preventDefault();
	
	$.ajax({
		type: "POST",
		url:"profile/uploadM",
		data:new FormData(this),
		processData: false,
		cache: false,
		contentType: false,
		success: function(data){
			if(data == 'Yes')
			{
				window.location = baseURL()+'user/profile';
			}
			else
			{
				alert("Image could not be uploaded")
			}
		}
	})
})



	
/*******************************************************************************************************************/
//buddhika	
	$(document).on('click', '#projectcommentsCount' ,function(){
		$this = $(this)
		var postID = $(this).data("id2")
		var parent = $(this).closest('.post')
		$('#projectcomment-Wrapper', parent).toggle(1000)
		countprojectComment(postID, $this)
		getProjectPostComment(postID, $this)
	})
	
	//buddhika	
	$('#createProjectPostBtn').on('click', function(){
		$(this).hide(1000)
		$('#userProjectPostForm').show(1000)
	})
	
	//buddhika
$(document).on('click', '#reportcommentbtn', function(){
	var commentID = $('#reportcommentID').val();
	var reason1 = $('#reason1').val();
	var url = 'projectprofile/reportcomment';
	var value = {commentID:commentID, reason:reason1};
	postData(url, value).done(function(data){
		if(data == 'reported'){
			$('.reportcommentModalTitle').html("Thank you")
			$('.reportcommentModalBody').html("<p>We have received your complaint concerning this comment, we will deal with this issue accordingly and swiftly.</p>")
			$('.reportcommentModalFooter').html("")
		}
	});
})

//buddhika
$(document).on('click', '#editposttbtn', function(){

	var postID = $('#editpostID').val();
	var changes = $('#changes').val();
	var url = 'projectprofile/editpost';
	var value = {postID:postID, changes:changes};
	postData(url, value).done(function(data){
		if(data == 'edited'){
			$('.editModalTitle').html(" ")
			$('.editModalBody').html("<p>Changes saved.</p>")
			$('.editModalFooter').html("")

		}
	});
})

//buddhika
$('#EditPostModal').on('hidden.bs.modal', function () {
	var currentprojid2 = $('#currentprojID').val();
  window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid2;
})


//buddhika
$('#submitProjectPostBtn').on('click', function(){
	var userID = $('#isLoggedIn').val()
	var thisprojid = $('#currentprojID').val();
	var description = $('#descriptionProjectPost').val()
	var url = 'projectprofile/postProjectActivity';

	var value = {pID:thisprojid, description:description};
	postData(url, value).done(function(data){

		if(data == 'Posted'){
			$("form").trigger("reset")
			$('#updateProjectPostSpan').show(1000)
			$('#updatePost').html(data)
			getProjectPost()
			$('#updateProjectPostSpan').fadeOut(1500)
		}
	});
})

//buddhika
function getProjectPost(){
	var userID = $('#isLoggedIn').val();
	var thisprojid = $('#currentprojID').val();
	$.post("projectprofile/getAllProjectPost",{pid:thisprojid}, function(data,status){
		$('#showProjectComments').html(data)
		if($('#showProjectComments').html() !== '')
		{
			var n = 3;
			var i = setInterval(function(){  
				if(n == 0){
					checkLike()
					clearInterval(i);
				}
				n--;
			}, 400);
		}
	});
}

//buddhika
function getProjectPostComment(postID, $this)
{
	var url = 'projectprofile/getProjectComments';
	var value = {postID:postID};
	postData(url, value).done(function(data){
		var parent = $this.closest('.post')
		$('#projectcomment-Wrapper', parent).html(data)
		countprojectComment(postID, $this)
	});
}

//buddhika
function countprojectComment(postID, $this)
{
	var parent = $this.closest('.post')
	$.post("projectprofile/countprojectComments",{postID:postID}, function(data,status){
		$('#commentsCount',parent).html('<i class="fa fa-comments-o margin-r-5"></i> Comments ('+data+')')
	});
}

//buddhika
$(document).on('click', '#commentProjectPostBtn', function()
{
	$this = $(this)
	var parent = $this.closest('form')
	var postparent = $(this).closest('.post')
	var postID = $(this).data("id")
	var userID = $('#isLoggedIn').val()
	var description = $('#userProjectCommentText', parent).val()
	var posterID = $('#commentProjectPostBtn',parent).data("pid2")
	var currentprojid2 = $('#currentprojID').val();
	//alert(posterID)
	var url = 'projectprofile/sendProjectComments';
	var value = {postID:postID, userID:userID, posterID:posterID, description:description};
	postData(url, value).done(function(data){
		if(data == 'Commented'){
			$("form").trigger("reset")
			$('#updateProjectPostSpan').show(1000)
			$('#updateProjectPost').html(data)
			countprojectComment(postID, $this)
			getProjectPostComment(postID, $this)
			$(this).closest('#projectcommentsCount').click();
			$('#updateProjectPostSpan').fadeOut(15000)
		}
	});
	
			window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid2;
})

//buddhika
function deleteProjectPost(postID, userID)
{
	var currentprojid2 = $('#currentprojID').val();
	var url = 'projectprofile/deleteProjectPost';
	var value = {postID:postID};
	postData(url, value).done(function(data){
		if(data == 'deleted'){
		window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid2;
		}
	});
}

//buddhika
$(document).on('click', '#deleteprojectpostcomment', function()
{

	var commentID = $(this).data("id2")
	var userID = $('#isLoggedIn').val()
	var currentprojid2 = $('#currentprojID').val();
	//alert(posterID)
	var url = 'projectprofile/deleteProjectComment';
	var value = {commentID:commentID};
	postData(url, value).done(function(data){
		if(data == 'deleted'){
		window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid2;
		}
	});
})

//buddhika
$(document).on('click', '#reportcomment', function()
{
	var commentID = $(this).data("id2")
	document.getElementById("reportcommentID").value = commentID;
})


$(document).on('click', '#deleteprojectpost', function(){
	var userID = $('#userLogin').val()
	var memberID = $('#memberID').val()
	var postID = $(this).data("id2")
	if(userID == memberID)
	{
		deleteProjectPost(postID,userID);
	}
	else
	{
		alert("You cannot perform this action")
	}
})
$(document).on('click', '#editpost', function(){
	var userID = $('#userLogin').val()
	var memberID = $('#memberID').val()
	var postID = $(this).data("id3")
	$('#editpostID').val(postID)
	if(userID == memberID)
	{
		$('#EditPostModal').modal('show')
	}
	else
	{
		$('#EditPostModal').modal('hide')
	}
})