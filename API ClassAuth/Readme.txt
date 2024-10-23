

To get a JWT token, send a POST request to http://localhost:5000/api/auth/login with JSON payload:

{
  "Username": "user1",
  "Password": "password1"
}


You should get a response containing the JWT token.

To access the protected route, send a GET request to http://localhost:5000/api/protected with an Authorization header: