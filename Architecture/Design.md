# Cursed Paint

## Overview

Cursed Paint aims to be a flexible and powerful ASCII/ANSI-art editor. Its goal is to provide its users with a modern art workflow and modern tools for this old-school art medium.

## Context

ASCII art is an art medium that lacks proper tooling for efficient workflows. Programs such as REXPaint provide a lot of flexibility in the art-making process but lack in the UX department. Other tools like PabloDRAW provide a better experience but are too focused on specific spheres of the ASCII art scene, such as banner design. Cursed Paint aims to be a general purpose ASCII art tool that provides a welcoming experience, inspired by modern art-making tools such as Adobe Photoshop, and Aseprite.

## Goals

- Character/Tile set swapping
- "Native" zoom (use multi-resolution character-sets, or scale font-size)
- Grayscale characters (automatic blending between fg and bg colors)
- Palette editing
- Gradient editing (define custom glyphs for gradient)
- Gradient-enabled painting (Brush automatically anti-aliases using gradient)
- Box-characters continual painting (box lines connect naturally as you draw)
- Layers with blending modes designed for ASCII art (glyph, foreground, background)
- Copy/Paste compatible with system clipboard
- Animation tools (simple frame system)
- Export to image format
- Restricted compatibility modes: Strict ASCII (Printable 7-bit chars, no color), Strict ANSI (Codepage 437, CGA palette)

- Level 0
  - 'Saving' and 'Loading' functionality
  - An 'Artboard' that displays the currently loaded piece
  - Simple navigation: 'Panning', 'Zooming'.
- Level 1
  - A 'Glyph' selector
  - A 'Foreground' and 'Background' color selector
  - A 'Pen' tool that draws a Glyph to the Artboard
  - A 'Fill' tool that covers an area of equal glyphs
  - A 'Line' tool, for drawing straight lines
  - A 'Rectangle' tool, for drawing rectangles
  - An 'Ellipse' tool, for drawing ellipses
  - Copy/Paste functionality 
- Level 2
  - Undo/Redo history
  - 'Layers' that allow the user to split the artwork into independent levels
- Level 3
  - Swappable 'Tilesets' that map to the given characters
  - A toggle to allow users to ignore Glyph, Foreground, and/or Background color when painting
  - Layer 'Blending modes' (Glyph, Foreground, Color)
- Level 4
  - 'Smart Zoom' that uses multi-resolution Tileset groups to provide zooming capabilities
  - A 'Soft brush'
  - A 'Gradient' selector


- A drawing canvas that accepts mouse input
---
- A 'Swatch' selector which applies a combination of glyph, foreground and background.
- A 'Gradient' selector that allows the user to specify a gradient in terms of Swatches
- A 'Brush' selector, which allows users to define a set of properties for painting
---
- A 'Fill' tool to fill the canvas with a given Swatch
- A 'Pen' tool that paints Swatches directly onto the canvas
- A 'Cell' tool, which smartly paints box-drawing characters
- A 'Paintbrush' tool that allows the user to use a Brush to paint with
- A 'Line' tool that allows users to draw straight lines
