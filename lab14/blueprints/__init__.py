from flask import Flask
from blueprints.user_routes import user_bp
from blueprints.login_routes import login_bp

def ConnectRoutings(appname):
    appname.register_blueprint(user_bp, url_prefix='/Controls')
    appname.register_blueprint(login_bp, url_prefix='/Mockups')
    