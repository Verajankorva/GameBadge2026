-- Game Badges example script 2026.
-- Author: Antti V

function HelloWorld()
	print("Hello world")
end

function GiveValue()
	return 10 + 10
end

function AddValues(a, b)
	return a + b
end

print("Running Lua startup script.")

v = GiveValue()
print(string.format("Value is %d", v))

v1 = 10
v2 = 40
v = AddValues(v1, v2)
print(string.format("%d + %d is %d", v1, v2, v))

--[[
i = 0

for i=1, 10, 1 do
	print(i)
end

while (i < 10) do
	print(i)
	i = i + 1
end
--]]

--[[
a = {}
for i=0, 9 do
	a[i] = i
end

for v in pairs(a) do
	print(v)
end
--]]