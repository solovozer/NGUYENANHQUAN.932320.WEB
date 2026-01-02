from blueprints.hospitals_routes import hospital_bp
from blueprints.labs_routes import lab_bp
from blueprints.doctors_routes import doctor_bp
from blueprints.patients_route import patient_bp

def ConnectRoutings(appname):
    appname.register_blueprint(hospital_bp, url_prefix='/Hospitals')
    appname.register_blueprint(lab_bp, url_prefix='/Labs')
    appname.register_blueprint(doctor_bp, url_prefix='/Doctors')
    appname.register_blueprint(patient_bp, url_prefix='/Patients')


