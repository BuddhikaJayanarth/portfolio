<?php
	/////////////////////////////////////////////////////////////////////////////
	/**
	***  AccessLeve for projects
	**/
	////////////////////////////////////////////////////////////////////////////
	$userID = $this->session->userdata('userID');
	$query = $this->db->query("SELECT * FROM project_members");
	$result = $query->result_array();
	$projStyle = "";
	$memberID = "";
	foreach($result as $projMember)
	{
		$member = $projMember["userID"];
		if($userID == $member)
		{
			$memberID = $member;
		}
	}
	if($this->session->userdata('accessLevel') >= 3)
	{
		$projStyle = "none";
		$myCommentStyle = "none";
	}
	else
	{
		if($userID != $memberID)
		{
			
				
			$projStyle = "none";
			$myCommentStyle = "none";
		}
		else
		{
			$projStyle = "block";
			$myCommentStyle = "block";
		}
	}
	
	echo '<input type="hidden" id="userLogin" value="'.$userID.'" /><input type="hidden" id="memberID" value="'.$memberID.'" />';
?>