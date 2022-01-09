#lang racket
(require "move.rkt")
(require "state.rkt")



(define initial-state (string->state "...........BACDBCDA"))

(define m (first (moves-from 14)))
