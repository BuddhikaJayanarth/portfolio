

      <div class="form-group has-feedback">
      	<label>Title</label>
        <select class="form-control" id="title">
        	<option></option>
            <option>Dr.</option>
            <option>Prof.</option>
            <option>Mr.</option>
            <option>Mrs.</option>
            <option>Ms.</option>
        </select>
      </div>
      <div class="form-group has-feedback">
      	<input type="text" class="form-control" id="username" placeholder="Username">
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" id="fname" placeholder="First name">
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="text" class="form-control" id="lname" placeholder="Last name">
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <label>Gender</label>
        <select id="gender" class="form-control">
        	<option></option>
        	<option>Male</option>
            <option>Female</option>
        </select>
        <span class="help-block"></span>
      </div>
      <div class="form-group">
        <div class="input-group date">
        <input type="text" class="form-control pull-right" id="DOB" placeholder="Date of Birth (DD/MM/YYY)">
          <div class="input-group-addon">
            <i class="fa fa-calendar"></i>
          </div>
          
        </div>
        <!-- /.input group -->
      </div>
      <div class="form-group has-feedback">
        <input type="email" class="form-control" id="email" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
        <span id="errorEmail" class="help-block"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="password" class="form-control" id="password" placeholder="Password">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
        <span id="errorPwd" class="help-block"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="password" class="form-control" id="R_password" placeholder="Confirm password">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
        <span id="errorRpwd" class="help-block"></span>
      </div>
      <div class="form-group has-feedback">
      	<input type="text" class="form-control" id="address" placeholder="Address">
        <span class="glyphicon glyphicon-road form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
      	<input type="text" class="form-control" id="city" placeholder="City">
        <span class="form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
      	<input type="text" class="form-control" id="zip" placeholder="Zip Code">
        <span class="form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
      	<input type="text" class="form-control" id="phone" placeholder="Mobile Number">
        <span class="glyphicon glyphicon-phone-alt form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
      	<input type="text" class="form-control" id="country" placeholder="Country">
        <span class="glyphicon glyphicon-globe form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck">
            <label>
              <input id="t_c" type="checkbox"> I agree to the <a href="#">terms</a>
            </label>
          </div>

        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <button type="button" id="regBtn" data-id1="external" class="btn btn-primary btn-block btn-flat">Register</button>
        </div>
        <!-- /.col -->
      </div>
    
    
   