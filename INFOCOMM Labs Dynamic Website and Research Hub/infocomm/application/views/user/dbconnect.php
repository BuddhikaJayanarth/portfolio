<?php

	/*$sql = "INSERT INTO dummy (id, name) VALUES ('','daniel')";
	if($this->db->query($sql)){
		echo "inserted";
	}else{
		echo "not inserted";
	}*/
	$title = 'ourTeam';
	$newTitle = preg_split('/(?=[A-Z])/', $title);
?>