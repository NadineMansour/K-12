class SessionsController < ApplicationController
  def login
    redirect_to("/views/session")
  end
  def login_attempt
    authorized_user = student.authenticate(params[:username_or_email],params[:login_password])
    if authorized_user
      session[:user_id]= authorized_user.student_id
      session[:username]=authorised_user.student_name
      flash[:notice] = "Wow Welcome again, you logged in as #{authorized_user.username}"
    
      redirect_to(:action => 'home') 
    else
      flash[:notice] = "Invalid Username or Password"
      flash[:color]= "invalid"
      render "login"	
    end
  end
  def logout
  	session[:user_id]= nil
      session[:username]= nil
      redirect_to(:action => "login")
  end

  def home
  	#game page
  	redirect_to("Website/app/views/home/index.html.erb")
  end
end
