'use strict'

Person = require('./Person')

class Program
	constructor: ->
		@init()

	init: ->
		person = new Person('Name of Person')
		console.log(person.getName())
		return

new Program