from flask_wtf import FlaskForm
from wtforms import PasswordField, StringField
from wtforms.validators import DataRequired, Email, EqualTo, Length, Regexp

class RegisterForm(FlaskForm):
    email = StringField('Email', validators=[DataRequired(message="The Email field is required."), Email()])
    password = PasswordField('Password', validators=[
        DataRequired(message="The Password field is required."),
        Length(min=8, message="Passwords must be at least 8 characters."),
        Regexp(r'(?=.*[a-z])', message="Passwords must have at least one lowercase ('a'-'z')."),
        Regexp(r'(?=.*[A-Z])', message="Passwords must have at least one uppercase ('A'-'Z')."),
        Regexp(r'(?=.*[^a-zA-Z0-9])', message="Passwords must have at least one non alphanumeric character.")
    ])
    confirmpassword = PasswordField('Confirm password', validators=[
        DataRequired(),
        EqualTo('password', message="Passwords must match.")
    ])

class LoginForm(FlaskForm):
    email = StringField('Email', validators=[DataRequired(message="The Email field is required."), Email()])
    password =  PasswordField('Password', validators=[DataRequired()], render_kw={"required": "required"})
    