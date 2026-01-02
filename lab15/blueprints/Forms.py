from flask_wtf import FlaskForm
from wtforms import StringField, IntegerField
from wtforms.validators import Regexp



class HospitalForm(FlaskForm):
    id = IntegerField('Id')
    name = StringField('Name')
    address = StringField('Address')
    phone = IntegerField('Phone Number', validators=[Regexp(r'^\d{10}$')])

class LabForm(FlaskForm):
    id = IntegerField('Id')
    name = StringField('Name')
    address = StringField('Address')

class DoctorForm(FlaskForm):
    id = IntegerField('Id')
    name = StringField('Name')
    specialty = StringField('Specialty')

