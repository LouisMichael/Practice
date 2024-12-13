import numpy as np
a = np.array([[94, 22], [34, 67]])
b = np.array([8400, 5400])
x = np.linalg.solve(a, b)
print(x)

a = np.array([[26, 67], [66, 21]])
b = np.array([12748, 12176])
x = np.linalg.solve(a, b)
print(x)