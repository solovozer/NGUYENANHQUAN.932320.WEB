from blueprints.Routes.login_routes import login_bp

def ConnectRoutings(appname):
    appname.register_blueprint(login_bp)
