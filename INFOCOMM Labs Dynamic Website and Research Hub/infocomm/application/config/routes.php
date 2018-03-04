<?php
defined('BASEPATH') OR exit('No direct script access allowed');

/*
| -------------------------------------------------------------------------
| URI ROUTING
| -------------------------------------------------------------------------
| This file lets you re-map URI requests to specific controller functions.
|
| Typically there is a one-to-one relationship between a URL string
| and its corresponding controller class/method. The segments in a
| URL normally follow this pattern:
|
|	example.com/class/method/id/
|
| In some instances, however, you may want to remap this relationship
| so that a different class/function is called than the one
| corresponding to the URL.
|
| Please see the user guide for complete details:
|
|	https://codeigniter.com/user_guide/general/routing.html
|
| -------------------------------------------------------------------------
| RESERVED ROUTES
| -------------------------------------------------------------------------
|
| There are three reserved routes:
|
|	$route['default_controller'] = 'welcome';
|
| This route indicates which controller class should be loaded if the
| URI contains no data. In the above example, the "welcome" class
| would be loaded.
|
|	$route['404_override'] = 'errors/page_missing';
|
| This route will tell the Router which controller/method to use if those
| provided in the URL cannot be matched to a valid route.
|
|	$route['translate_uri_dashes'] = FALSE;
|
| This is not exactly a route, but allows you to automatically route
| controller and method names that contain dashes. '-' isn't a valid
| class or method name character, so it requires translation.
| When you set this option to TRUE, it will replace ALL dashes in the
| controller and method URI segments.
|
| Examples:	my-controller/index	-> my_controller/index
|		my-controller/my-method	-> my_controller/my_method
*/
/*$route['default_controller'] = 'welcome';
$route['404_override'] = '';
$route['translate_uri_dashes'] = FALSE;*/

/////////////////////////////////////////////////////
$route['default_controller'] = 'pages/homepage';
$route['(:any)'] = 'pages/loadPages/$1';
$route['user/(:any)'] = 'pages/loadUsers/$1';
$route['admin'] = 'pages/loadAdmin';
$route['admin/login'] = 'pages/loadAdmin';
$route['admin/(:any)'] = 'pages/loadAdminPage/$1';
///////////////////////////////////////////////////////////////////////////
$route['applyJob/add'] = 'user_controller/jobApplication';
$route['user/login/verify'] = 'user_controller/loginUser';
$route['activate/activateUser'] = 'user_controller/activateUser';
$route['user/register/adduser'] = 'user_controller/registerUserController';
$route['user/register/checkValidUE'] = 'user_controller/checkUsername_Email';
$route['user/forgot/checkEmail'] = 'user_controller/checkEmail';
$route['logout/logout'] = 'user_controller/logout';

$route['user/(:any)/getupdatedprofile'] = 'user_controller/getUpdatedProfile';
$route['user/(:any)/updatebio'] = 'user_controller/updateUserController';
$route['user/(:any)/updatesocial'] = 'user_controller/updateUserSocialController';
$route['user/(:any)/updatesecurity'] = 'user_controller/updateUserSecurityController';
$route['user/reset/resetPassword'] = 'user_controller/ChangeUserSecurityController';
$route['user/(:any)/disable'] = 'user_controller/deleteUserAccount';
$route['user/(:any)/addEdu'] = 'user_controller/addUserQualification';
$route['user/(:any)/deleteEducation'] = 'user_controller/deleteUserQualification';

$route['user/(:any)/getuserTimeline'] = 'user_controller/getUserTimeline';

$route['user/profile/follow'] = 'user_controller/followerUser';
$route['user/profile/unfollow'] = 'user_controller/unfollowUser';
$route['user/(:any)/countFollowers'] = 'user_controller/countFollowing';
$route['user/(:any)/checkFollow'] = 'user_controller/checkUserFollower';

$route['user/profile/report'] = 'user_controller/reportUser';

$route['user/profile/postActivity'] = 'user_controller/getActivity';
$route['user/profile/getAllPost'] = 'user_controller/getUserActivity';
$route['user/profile/deletePost'] = 'user_controller/deleteUserPost';

$route['user/profile/sendComments'] = 'user_controller/postComments';
$route['user/profile/getComments'] = 'user_controller/getUserActivityComments';
$route['user/profile/countComments'] = 'user_controller/countComments';

$route['user/profile/checkMyLikes'] = 'user_controller/checkLikes';
$route['user/profile/likeComments'] = 'user_controller/likeUserComments';

$route['(:any)/getNotifications'] = 'user_controller/getNotifications';
$route['(:any)/(:any)/getNotifications'] = 'user_controller/getNotifications';
$route['(:any)/(:any)/setIsRead'] = 'user_controller/setIsReadNotification';

$route['user/publications/addpub'] = 'user_controller/addPublication';
$route['user/publications/update'] = 'user_controller/updatePublication';

$route['user/security/add'] = 'user_controller/postSecurityQuestion';
$route['user/security/update'] = 'user_controller/updateSecurityQuestion';
$route['user/security/change'] = 'user_controller/changeSecurityQuestion';

$route['user/formtest/uploadM'] = 'user_controller/profileImageUpload';

$route['admin/(:any)/updatesecurity'] = 'user_controller/updateUserSecurityController';
$route['admin/login/verify'] = 'user_controller/loginUser';
$route['user/projectprofile/searchmember'] = 'user_controller/searchie';

//////////////////////////////////////////////////////////////////////
$route['admin/users/delete'] = 'admin_controller/deleteUser';
$route['admin/users/editAccess'] = 'admin_controller/editAccess';

$route['activate/send'] = 'admin_controller/activateUser';
$route['contact/submit'] = 'admin_controller/contact';

$route['admin/viewVacancies/delete'] = 'admin_controller/deleteVacancy';
$route['admin/viewVacancies/edit'] = 'admin_controller/editVacancy';
$route['admin/viewVacancies/fill'] = 'admin_controller/fillVacancy';
$route['admin/addVacancies/new'] = 'admin_controller/newVacancy';
$route['admin/applications/delete'] = 'admin_controller/deleteApp';

$route['admin/publications/delete'] = 'admin_controller/deletePub';
$route['user/profile/deletePub'] = 'admin_controller/deletePub';

$route['admin/categories/new'] = 'admin_controller/newProjectCat';
$route['admin/categories/delete'] = 'admin_controller/deleteProjectCat';

$route['admin/addCollaborators/new'] = 'admin_controller/newCollaborator';
$route['admin/addCollaborators/logo'] = 'media_controller/addCollaboratorImage';
$route['admin/collaborators/edit'] = 'admin_controller/editCollaborator';
$route['admin/collaborators/delete'] = 'admin_controller/deleteCollaborator';

$route['admin/editAbout/image'] = 'media_controller/editAboutImage';
$route['admin/editAbout/text'] = 'admin_controller/editAboutUs';

$route['admin/termsAndConditions/text'] = 'admin_controller/editTC';

$route['(:any)/search'] = 'user_controller/searchDD';
$route['user/(:any)/search'] = 'user_controller/searchDD';

$route['admin/events/deleteImg'] = 'admin_controller/deleteEventImage';
$route['admin/events/delete'] = 'admin_controller/deleteEvent';
$route['admin/events/add'] = 'admin_controller/addEvent';
$route['admin/events/edit'] = 'admin_controller/editEvent';
$route['admin/addEvent/uploadImage'] = 'media_controller/addEventImage';
$route['admin/events/uploadImage'] = 'media_controller/addEventImage';

$route['admin/news/delete'] = 'admin_controller/deleteNews';
$route['admin/news/edit'] = 'admin_controller/editNews';
$route['admin/addNews/add'] = 'admin_controller/addNews';

$route['admin/reports/reject'] = 'admin_controller/rejectReport';
$route['admin/reports/accept'] = 'admin_controller/acceptReport';

//////////////////////////////////////////////////////

$route['user/projects/createproject'] = 'user_controller/createProjectController';
$route['admin/contact/editcontact'] = 'admin_controller/editContactController';
$route['user/projects/editproject'] = 'user_controller/editProjectController';
$route['admin/projects/deleteprojectadmin'] = 'admin_controller/deleteProjectController';
$route['admin/ourTeamCategories/remove'] = 'admin_controller/deletePositionController';
$route['admin/ourTeamCategories/edit'] = 'admin_controller/editPositionController';
$route['admin/ourTeamCategories/add'] = 'admin_controller/addPositionController';
$route['user/projectprofilebar/unfollowproject'] = 'user_controller/unfollowProjectController';
$route['user/projectprofilebar/followproject'] = 'user_controller/followProjectController';
$route['user/projectprofile/searchmember'] = 'user_controller/searchmembers';
$route['user/projectprofile/addmember'] = 'user_controller/addmemberController';
$route['user/projectprofile/removemember'] = 'user_controller/removememberController';
$route['user/projectprofile/searchpubs'] = 'user_controller/searchpubs';
$route['user/projectprofile/addpub'] = 'user_controller/addpubController';
$route['user/projectprofile/removepub'] = 'user_controller/removepubController';
$route['user/projectprofile/removeev'] = 'user_controller/removeevController';
$route['user/projectprofile/searchev'] = 'user_controller/searchev';
$route['user/projectprofile/addev'] = 'user_controller/addevController';
$route['user/projectprofile/searchfun'] = 'user_controller/searchfun';
$route['user/projectprofile/addfun'] = 'user_controller/addfunController';
$route['user/projectprofile/removefun'] = 'user_controller/removefunController';
$route['user/projectprofile/createfun'] = 'user_controller/createfunController';
$route['user/projectprofile/searchcol'] = 'user_controller/searchcol';
$route['user/projectprofile/addcol'] = 'user_controller/addcolController';
$route['user/projectprofile/removecol'] = 'user_controller/removecolController';
$route['user/projectprofile/getAllProjectPost'] = 'user_controller/getProjectActivity';
$route['user/projectprofile/postProjectActivity'] = 'user_controller/createProjectActivity';
$route['user/projectprofile/sendProjectComments'] = 'user_controller/postProjectComments';
$route['user/projectprofile/getProjectComments'] = 'user_controller/getProjectActivityComments';
$route['user/projectprofile/countprojectComments'] = 'user_controller/countprojectComments';
$route['user/projectprofile/deleteProjectPost'] = 'user_controller/deleteProjectPosts';
$route['user/projectprofile/deleteProjectComment'] = 'user_controller/deleteProjectComments';
$route['user/projectprofile/reportcomment'] = 'user_controller/reportcomment';
$route['user/projectprofile/editpost'] = 'user_controller/editpost';
$route['user/projectprofilebar/uploadImage'] = 'media_controller/addProjectImage';
$route['user/editproject/uploadImage'] = 'media_controller/addProjectImage';
$route['user/projectprofile/uploadFunderImage'] = 'media_controller/addFundersImage';





