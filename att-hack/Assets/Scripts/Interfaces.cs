﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegates
public delegate void ValueChange(float value);

// Enums
public enum InputType {

	Velocity,
	Pitch,
	Knob

}

public enum Format {

	Grid,
	Line

}

// Interaces
public interface IOutputModule {

	Board _board { get; set; }

	// Any Output module must have an implementation
	// for SubscribeToInput
	void SubscribeToInput(IInputModule input);
	void UnsubscribeFromInput(IInputModule input);


}

public interface IInputModule {

	InputType _inputType { get; set; }
	Board _board { get; set; }

	// Any Input Module
	// Create an event that other modules can subscribe to when this input changes
	event ValueChange OnValueChange;
	void DestroyInput();

}