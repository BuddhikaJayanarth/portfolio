<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Untitled Document</title>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js"></script>  
           <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
           <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>

<body>

<?php
$query = $this->db->get("test");
$message = $query->result();

$output = "ID----NAME----AGE";
foreach($message as $m){
	$output .= "<br/>".$m->id."---".$m->name."----".$m->age.'-----<button data-id1="'.$m->id.'" id="btnUser">Delete</button>';
}
$output .= "<br/>------------------------";
echo $output;

?>
<script>
	$(document).ready(function() {
		$(document).on('click','#btnUser', function(){
			var id = $(this).data("id1")
			$.post('formtest/delete',{id:id},function(result, status){
				if(status){
					location.reload();
					alert("deleted")
					
				}
			})
		})
    });
</script>
</body>
</html>