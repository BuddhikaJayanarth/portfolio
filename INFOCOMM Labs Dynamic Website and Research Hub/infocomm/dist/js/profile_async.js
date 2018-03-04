// JavaScript Document
$(document).ready(function() {
	var url = window.location.href;
	var userID = $('#isLoggedIn').val()
	
	if(url == $('#baseURL').val()+'user/profile')
	{
		getUpdates();
		getUserTimeline();
		getUserPost();
		
		$(window).scroll(function() {
			if($(document).height() - $(window).height() == $(window).scrollTop())
			{
				getUserPost();
			}
		});
	}
	else
	{
		if(url.indexOf('?') != -1)
		{
			var profileURL = url.split('?')[0]
			var pageID = url.split('?')[1].split('=')[1]
			if($.isNumeric(pageID))
			{
				getMyPost(pageID)
			}
		}
		
	}
	checkUserFollower();
	getProjectPost();
	if(userID !== "")
	{
		getNotification()
	}
	
});